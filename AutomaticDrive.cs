using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticMath
{
    public class AutomaticDrive : MonoBehaviour
    {
        public float speed = 5;
        public float stopPoint = 0.1f;
        public GameObject fuel;
        Vector3 direction;

        private void Start()
        {
            //direction = fuel.transform.position - this.transform.position; //finds the vector not magnitude
            //Coords dircNormal = HolisticMath.GetNormal(new Coords(direction));
            //direction = dircNormal.ToVector();
            //float angle_ = HolisticMath.Angle(new Coords(this.transform.up), new Coords(direction));
            //bool clockwise = false;
            //if (HolisticMath.Cross(new Coords(this.transform.up), dircNormal).z < 0)
            //{
            //    clockwise = true;
            //}
            //Coords newDirection = HolisticMath.Rotate(new Coords(0, 1, 0), angle_, clockwise);
            //this.transform.up = new Vector3(newDirection.x, newDirection.y, newDirection.z); //because the Tank it self is looking towords up so we change it so it look at up

            this.transform.up = HolisticMath.LookAt2D(new Coords(this.transform.forward), new Coords(this.transform.position), new Coords(fuel.transform.position)).ToVector();

            //direction = fuel.transform.position - this.transform.position;
            //Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));
            //direction = dirNormal.ToVector(); // directon will be something static and only it will be multiplied by speed so this is how it increases

        }

        void Update()
        {
            if (HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stopPoint)
                transform.position += direction * speed * Time.deltaTime;

        }



    }
}