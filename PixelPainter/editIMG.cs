using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace PixelPainter
{   
    
    enum ImageOperation
    {
        OpAdd = 0,
        OpSubtract,
        OpMultiply,
        OpDivide,
        OpMax,
        OpMin,
        OpAbs,
        OpAbDiff
    }


    public partial class editIMG : Form
    {        
        public editIMG()
        {
            InitializeComponent();
        }

        private void openBTN_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {  //DialogResult는 windows forms 라이브러리에서 제공하는 열거형.
                //대화상자(Dialog)에서 반환되는 값 표현
                pictureBox1.Load(openFileDialog1.FileName);

                Mat src1 = Cv2.ImRead(openFileDialog1.FileName);
                //pictureBox1.Image = BitmapConverter.ToBitmap(src1);

            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {

        }

        private void OpcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mat src1 = Cv2.ImRead(openFileDialog1.FileName);
            Mat src2 = new Mat(src1.Size(), MatType.CV_8UC3, new Scalar(0, 0, 30));

            Mat dst = new Mat();

            ImageOperation selType = ImageOperation.OpAbDiff;

            switch (selType)
            {
                case ImageOperation.OpAdd:
                    Cv2.Add(src1, src2, dst);
                    break;
                case ImageOperation.OpSubtract:
                    Cv2.Subtract(src1, src2, dst);
                    break;
                case ImageOperation.OpMultiply:
                    Cv2.Multiply(src1, src2, dst);
                    break;
                case ImageOperation.OpDivide:
                    Cv2.Divide(src1, src2, dst);
                    break;
                case ImageOperation.OpMax:
                    Cv2.Max(src1, src2, dst);
                    break;
                case ImageOperation.OpMin:
                    Cv2.Min(src1, src2, dst);
                    break;
                case ImageOperation.OpAbs:
                    Cv2.Multiply(src1, src2, dst);
                    Cv2.Abs(dst);
                    break;
                case ImageOperation.OpAbDiff:
                    Mat matMul = new Mat();
                    Cv2.Multiply(src1, src2, matMul);
                    Cv2.Absdiff(src1, matMul, dst);
                    break;
            }

            string strOperation = selType.ToString();

            Cv2.ImShow(strOperation, dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
