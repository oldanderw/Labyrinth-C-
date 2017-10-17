using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalReviewLab
{
    class Room
    {
        int right;
        int left;
        int forward;
        int back;
        Switches theswitch = new Switches();

        public Switches TheSwitch
        {
            get
            {
                return theswitch;
            }

            set
            {
                theswitch = value;
            }
        }

        public int Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }

        public int Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        public int Forward
        {
            get
            {
                return forward;
            }

            set
            {
                forward = value;
            }
        }

        public int Back
        {
            get
            {
                return back;
            }

            set
            {
                back = value;
            }
        }
    }
}
