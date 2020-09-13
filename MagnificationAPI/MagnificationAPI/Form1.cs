using System;
using System.Linq;
using System.Windows.Forms;



namespace MagnificationAPI
{


    public partial class Form1 : Form
    {
        #region ColorArrayInitialize
        //initialize all of our Color Arrays
        public float[] Identity;
        public float[] Negative;
        public float[] Sepia;
        public float[] Red;
        public float[] Yellow;
        public float[] Orange;
        public float[] Green;
        public float[] Blue;
        public float[] Indigo;
        public float[] Violet;
        public float[] Redinverse;
        public float[] Yellowinverse;
        public float[] Orangeinverse;
        public float[] Greeninverse;
        public float[] Blueinverse;
        public float[] Indigoinverse;
        public float[] Violetinverse;
        public float[] Sunrise;


        //Initialize our List Arrays
        public float[][] Arraylist;
        public float[][] Rainbowlist;

        public float[] CurrentArray;
        public float[] NextArray;
        public bool cycleon = false;
        #endregion


        public Form1()
        {
            InitializeComponent();

            //If the program is not already initialized, we initialize maginifcation
            if (!Program.MagInitialize())
            {
                Program.MagInitialize();
            }
            //Here we turn on the full screen magnification. in this case, it will only work for a 1920x1080 monitor

            //finally, we set the screen to this color
            Program.MagSetFullscreenTransform(1, 1920 / 2, 1080 / 2);
            #region DefineArrays

            Identity = new float[] {
                1.0f,  0.0f,  0.0f,  0.0f,  0.0f ,
                0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
                0.0f,  0.0f,  1.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Negative = new float[] {
                -1.0f,  0.0f,  0.0f,  0.0f,  0.0f ,
                0.0f,  -1.0f,  0.0f,  0.0f, 0.0f,
                0.0f,  0.0f,  -1.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  1.0f,  1.0f,  0.0f,  1.0f};

            Sepia = new float[] {
                .393f,  0.349f,  0.272f,  0.0f,  0.0f ,
                0.769f,  .686f,  0.534f,  0.0f, 0.0f,
                0.189f,  .168f,  .131f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Red = new float[] {
                0.3f,  0.0f,  0.0f,  0.0f,  0.0f ,
                0.6f,  0.0f,  0.0f,  0.0f, 0.0f,
                0.1f,  0.0f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Orange = new float[] {
                0.4f,  0.15f,  0.0f,  0.0f,  0.0f ,
                0.6f,  0.3f,  0.0f,  0.0f, 0.0f,
                0.1f,  0.05f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Yellow = new float[] {
                0.3f,  0.3f,  0.0f,  0.0f,  0.0f ,
                0.6f,  0.6f,  0.0f,  0.0f, 0.0f,
                0.1f,  0.1f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Green = new float[] {
                0.0f,  0.3f,  0.0f,  0.0f,  0.0f ,
                0.0f,  0.6f,  0.0f,  0.0f, 0.0f,
                0.0f,  0.1f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Blue = new float[] {
                0.0f,  0.0f,  0.3f,  0.0f,  0.0f ,
                0.0f,  0.0f,  0.6f,  0.0f, 0.0f,
                0.0f,  0.0f,  0.1f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Indigo = new float[] {
                0.3f,  0.0f,  0.3f,  0.0f,  0.0f ,
                0.3f,  0.0f,  0.6f,  0.0f, 0.0f,
                0.0f,  0.0f,  0.1f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.1f,  0.0f,  1.0f};

            Violet = new float[] {
                0.3f,  0.0f,  0.3f,  0.0f,  0.0f ,
                0.6f,  0.0f,  0.6f,  0.0f, 0.0f,
                0.1f,  0.0f,  0.1f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Redinverse = new float[] {
                -0.3f,  0.0f,  0.0f,  0.0f,  0.0f ,
                -0.6f,  0.0f,  0.0f,  0.0f, 0.0f,
                -0.1f,  0.0f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  0.0f,  0.0f,  0.0f,  1.0f};

            Orangeinverse = new float[] {
                -0.4f,  -0.15f,  0.0f,  0.0f,  0.0f ,
                -0.6f,  -0.3f,  0.0f,  0.0f, 0.0f,
                -0.1f,  -0.05f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  1.0f,  0.0f,  0.0f,  1.0f};

            Greeninverse = new float[] {
                0.0f,  -0.3f,  0.0f,  0.0f,  0.0f ,
                0.0f,  -0.6f,  0.0f,  0.0f, 0.0f,
                0.0f,  -0.1f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  1.0f,  0.0f,  0.0f,  1.0f};

            Blueinverse = new float[] {
                0.0f,  0.0f,  -0.3f,  0.0f,  0.0f ,
                0.0f,  0.0f,  -0.6f,  0.0f, 0.0f,
                0.0f,  0.0f,  -0.1f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  1.0f,  0.0f,  1.0f};

            Indigoinverse = new float[] {
                -0.3f,  0.0f,  -0.3f,  0.0f,  0.0f ,
                -0.3f,  0.0f,  -0.6f,  0.0f, 0.0f,
                0.0f,  0.0f,  -0.1f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  0.0f,  1.0f,  0.0f,  1.0f};

            Violetinverse = new float[] {
                -0.3f,  0.0f,  -0.3f,  0.0f,  0.0f ,
                -0.6f,  0.0f,  -0.6f,  0.0f, 0.0f,
                -0.1f,  0.0f,  -0.1f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  0.0f,  1.0f,  0.0f,  1.0f};

            Yellowinverse = new float[] {
                -0.3f,  -0.3f,  0.0f,  0.0f,  0.0f ,
               - 0.6f,  -0.6f,  0.0f,  0.0f, 0.0f,
                -0.1f,  -0.1f,  0.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  1.0f,  0.0f,  0.0f,  1.0f};

            Sunrise = new float[] {
                1.0f,  0.0f,  0.0f,  0.0f,  0.0f ,
                0.0f,  2.0f,  0.0f,  0.0f, 0.0f,
                0.0f,  0.0f,  1.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                1.0f,  -1.0f,  -1.0f,  0.0f,  1.0f};

            #endregion
            #region Arraylists
            Arraylist = new float[13][];
            Arraylist[1] = Identity;
            Arraylist[2] = Negative;
            Arraylist[3] = Sepia;
            Arraylist[4] = Red;
            Arraylist[5] = Green;
            Arraylist[6] = Blue;
            Arraylist[7] = Yellow;
            Arraylist[8] = Redinverse;
            Arraylist[9] = Blueinverse;
            Arraylist[10] = Greeninverse;
            Arraylist[11] = Yellowinverse;
            Arraylist[12] = Sunrise;


            Rainbowlist = new float[18][];
            Rainbowlist[1] = Identity;
            Rainbowlist[2] = Red;
            Rainbowlist[3] = Orange;
            Rainbowlist[4] = Yellow;
            Rainbowlist[5] = Green;
            Rainbowlist[6] = Blue;
            Rainbowlist[7] = Indigo;
            Rainbowlist[8] = Violet;
            Rainbowlist[9] = Negative;
            Rainbowlist[10] = Redinverse;
            Rainbowlist[11] = Sunrise;
            Rainbowlist[12] = Orangeinverse;
            Rainbowlist[13] = Yellowinverse;
            Rainbowlist[14] = Greeninverse;
            Rainbowlist[15] = Blueinverse;
            Rainbowlist[16] = Indigoinverse;
            Rainbowlist[17] = Violetinverse;


            #endregion

            //Define the Items in our ComboBox

            SetCombobox();

        }
        private void button1_Click(object sender, EventArgs e)
        {


        }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userchoice = comboBox1.Text;
            ArraySelection(userchoice);
            Program.MagSetFullscreenColorEffect(CurrentArray);
            
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

            if (checkBox1.Checked)
                cycleon = true;
            if (!checkBox1.Checked)
                cycleon = false;



            if (cycleon == true)
            {
                CurrentArray = new float[] {
                1.0f,  0.0f,  0.0f,  0.0f,  0.0f ,
                0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
                0.0f,  0.0f,  1.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};
                NextArray = new float[] {
                1.0f,  0.0f,  0.0f,  0.0f,  0.0f ,
                0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
                0.0f,  0.0f,  1.0f, 0.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  1.0f,  0.0f ,
                0.0f,  0.0f,  0.0f,  0.0f,  1.0f};

                int i = 0;
                var rand = new Random();
                int randomnumber = rand.Next(1, 12);
                //for (int i = 0; i < Identity.Length; i++)
                foreach (float element in Identity)
                {

                    CurrentArray[i] = Identity[i];
                    NextArray[i] = Rainbowlist[randomnumber][i];
                    i++;
                }

                TransitionArray();

            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        //the second button will uninitialize the magnification
        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentArray.SequenceEqual(Identity) == false)
            {
                CurrentArray = Identity;
                Program.MagSetFullscreenColorEffect(CurrentArray);
            }
        }


        public void TransitionArray()
        {
            int arraycycle = 1;
            while (cycleon == true)
            {
                int i = 0;
              
                foreach (float element in Identity)
                {
                    NextArray[i] = Rainbowlist[arraycycle][i];
                    i++;
                }


                int j = 0;
                while (CurrentArray.SequenceEqual(NextArray) == false & j < CurrentArray.Length)
                {
                    float compare = CurrentArray[j] - NextArray[j];

                    if (compare < .001 & compare > -.001)
                    {
                        CurrentArray[j] = NextArray[j];
                        j++;
                        
                    }

                    else if (compare > 0)
                    {
                        CurrentArray[j] = CurrentArray[j] - .005f;
                        Program.MagSetFullscreenColorEffect(CurrentArray);
                        System.Threading.Thread.Sleep(5);
                    }
                    else if (compare < 0)
                    {
                        CurrentArray[j] = CurrentArray[j] + .005f;
                        Program.MagSetFullscreenColorEffect(CurrentArray);
                        System.Threading.Thread.Sleep(5);
                    }


                }
                if (arraycycle < (Rainbowlist.Length-1))
                {
                
                    arraycycle++;
                }
                else
                {
                  
                    arraycycle = 1;

                }
                Program.MagSetFullscreenColorEffect(CurrentArray);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (cycleon == false)
                textBox5.Text = "CycleOff";
            else
                textBox5.Text = "CycleOn";
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
        public void SetCombobox()
        {
            comboBox1.Items.AddRange(new string[] { "Negative", "Sepia", "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet", "Redinverse", "Orangeinverse", "Yellowinverse", "Greeninverse", "Blueinverse", "Indigoinverse", "Violetinverse", "Sunrise" });

        }

        public void ArraySelection(string userchoice)
        {
            switch (userchoice)
            {
                case "Negative":
                    CurrentArray = Negative;
                    break;

                case "Sepia":
                    CurrentArray = Sepia;
                    break;

                case "Red":
                    CurrentArray = Red;
                    break;

                case "Green":
                    CurrentArray = Green;
                    break;

                case "Orange":
                    CurrentArray = Orange;
                    break;

                case "Indigo":
                    CurrentArray = Indigo;
                    break;

                case "Violet":
                    CurrentArray = Violet;
                    break;

                case "Blue":
                    CurrentArray = Blue;
                    break;

                case "Yellow":
                    CurrentArray = Yellow;
                    break;

                case "Redinverse":
                    CurrentArray = Redinverse;
                    break;

                case "Greeninverse":
                    CurrentArray = Greeninverse;
                    break;

                case "Blueinverse":
                    CurrentArray = Blueinverse;
                    break;

                case "Orangeinverse":
                    CurrentArray = Orangeinverse;
                    break;

                case "Indigoinverse":
                    CurrentArray = Indigoinverse;
                    break;

                case "Violetinverse":
                    CurrentArray = Violetinverse;
                    break;

                case "Yellowinverse":
                    CurrentArray = Yellowinverse;
                    break;

                case "Sunrise":
                    CurrentArray = Sunrise;
                    break;
            }


        }


    }




}








