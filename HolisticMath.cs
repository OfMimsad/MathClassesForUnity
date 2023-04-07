using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HolisticMath
{
    public class HolisticMath
    {
      static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
        {
            
            Coords direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
            float angle = Angle(forwardVector, direction);

            bool clockwise = false;
            if(Cross(forwardVector,direction).z < 0)
            {
                clockwise = true;
            }
            Coords newDir = Rotate(forwardVector, angle, clockwise);
            return newDir;

            
        }
        static public float Square(float value) //power by 2
        {
            return value * value;
        }
        static public float Distance(Coords point1, Coords point2)
        {
            float diffSquared = Square(point1.x - point2.x) + Square(point1.y - point2.y) + Square(point1.z - point2.z); //powerd by two
            float squareRoot = Mathf.Sqrt(diffSquared); // Raduical
            return squareRoot;
        }
        static public Coords GetNormal(Coords vector) //makes a normal distance and goes throw it //1
        {
            float lenght = Distance(new Coords(0, 0, 0), vector);
            vector.x /= lenght;
            vector.y /= lenght;
            vector.z /= lenght;
            return vector;
        }

        static public float Dot(Coords vector1, Coords vector2)
        {
            float vwX = vector1.x * vector2.x;
            float vwY = vector1.y * vector2.y;
            float vwZ = vector1.z * vector2.z;

            return vwX + vwY + vwZ;
        }
        static public float Angle(Coords vector1, Coords vector2)
        {

            float dotDivide = Dot(vector1, vector2) / Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2);
            return Mathf.Acos(dotDivide); //radians. For degrees * 180/Mathf.PI(adad pe);
                                          //Mathf.Acos finds the arccos.
        }

        static public Coords Rotate(Coords vector/*the direction you're facing*/, float angle/*the directopn you want to go  */, bool clockWise)
        {
            if (clockWise)
            {
                angle = 2 * Mathf.PI - angle;
            }
            float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
            float yVal = vector.x * Mathf.Sign(angle) + vector.y * Mathf.Cos(angle);
            return new Coords(xVal, yVal, 0);
        }

        static public Coords Cross(Coords Vvector1, Coords Wvector2)
        {
            return new Coords(Vvector1.y * Wvector2.z - Vvector1.z * Wvector2.y, Vvector1.z * Wvector2.x - Vvector1.x * Wvector2.z,
                      Vvector1.x * Wvector2.y - Vvector1.y * Wvector2.x);
        }

    }
}
