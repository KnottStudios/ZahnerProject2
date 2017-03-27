using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahnerProject
{
    public class ZahnerXandY
    {
        //ToDo change to int.  
        public string _numX;
        public string _numY;

        public string NumX {
            get {
                if (String.IsNullOrEmpty(_numX)) {
                    return "";
                }
                return _numX.ToString(); }
            set { 
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("NumY must be entered.");
                }
                _numX = value;

            }
        }

        public string NumY {
            get {
                if (String.IsNullOrEmpty(_numY))
                {
                    return "";
                }
                return _numY.ToString(); }
            set {
                if (String.IsNullOrEmpty(value)) {
                    throw new ApplicationException("NumY must be entered.");
                }
                _numY = value;
            }
        }
    }
}
