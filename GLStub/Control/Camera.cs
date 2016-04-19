using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLStub.Control
{
    public class Camera
    {
        public Camera()
        {
            XPos = 0;
            YPos = 0;
            ZPos = 0;
            XRot = 45;
            YRot = 0;
            CRadius = 80;
            IsPressed = false;
        }

        public float LastX;
        public float LastY;
        public float XPos;
        public float YPos;
        public float ZPos;
        public float XRot;
        public float YRot;
        public float CRadius;
        public bool IsPressed;
    }
}
