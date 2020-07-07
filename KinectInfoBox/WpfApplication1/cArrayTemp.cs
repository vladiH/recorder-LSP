using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Kinect;

namespace WpfApplication1
{
    class cArrayTemp
    {
        ArrayList arrImg = new ArrayList();
        ArrayList arrDepth = new ArrayList();
        ArrayList arrSkel = new ArrayList();
        public void Add(ColorImageFrame imageFrame){
            arrImg.Add(imageFrame);
        }
        public void Add(DepthImageFrame depthimageFrame){
            arrDepth.Add(depthimageFrame);
        }
        public void Add(SkeletonFrame skeletonFrame){
            arrSkel.Add(skeletonFrame);
        }
        public ArrayList getImg() {
            return arrImg;
        }
        public ArrayList getDepth() {
            return arrDepth;
        }
        public ArrayList getSkel() {
            return arrSkel;
        }
        public void Clear() {
            arrImg.Clear();
            arrSkel.Clear();
            arrDepth.Clear();
        }
    }
}
