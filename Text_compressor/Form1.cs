using System.IO;
namespace Text_compressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string input=textBox1.Text; //getting input to string variable
            int[] input_int = string2int(input);    //converting string to numbers
            int[] Coded = code(input_int);       //diffrence coding the input
            
            
            Coded =code_min(Coded);           //adding smalels diffrence to end of the file
            for (int i = 0; i < Coded.Length-1; i++)
                Coded[i] +=Math.Abs( Coded[Coded.Length-1])+1;   //adding the |smallest diffrence|
                                                                        // to avoid negative numbers in out

            string file_name = "Text_codded.txt";           //option #1 file name
            using (StreamWriter writer = new StreamWriter(file_name,false,System.Text.Encoding.UTF8))
            {
                for(int i=0;i<Coded.Length-1;i++)    
                    writer.Write((char)Coded[i]);    //writing the output to file as chars
                writer.Write("\n"+(int)Coded[Coded.Length-1]);    //write the last diffrence number to end opf the oputput
            }

            //printing
            for (int i = 0; i < Coded.Length-1; i++)
                listBox1.Items.Add((char)Coded[i]);
            listBox1.Items.Add(Coded[Coded.Length-1]);
            listBox1.Items.Add("File Saved!");
            
        }
        
        private int[] code_min(int[] output)
        {
            int min = output[0];
            for (int i = 0; i < output.Length; i++)
                min = Math.Min(min, output[i]);
            output[output.Length-1] = min;
            return output;
        }


        int[] string2int(string input)
        {
            int[] result = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
                result[i] = input[i];
            return result;
        }

        static int[] code(int[] input)
        {
            
            int[] output = new int[input.Length+1];
            output[0] = input[0];
            
            for (int i = 1; i < input.Length; i++)
            {
                output[i] = (int)(input[i] - input[i - 1]);
            }
            int min = output[0];
            


            return output;
        }
        static int[] decode(int[] input)
        {
            int[] output = new int[input.Length];
            output[0] = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                output[i] = (input[i] + output[i - 1]);
            }
            return output;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            string input = textBox2.Text;               //picking the input to decode
            int[] input_int = string2int(textBox2.Text);//turning the input to an int
            int diffrence = int.Parse(textBox5.Text);   //turning the diffrence in to int
            

            for (int i = 0; i < input.Length; i++)
                input_int[i]=input_int[i]-Math.Abs(diffrence)-1;    //adding the |diffrence|
           
            int[] output=decode(input_int);             //decoding

            for (int i = 0; i < input.Length; i++)
                listBox1.Items.Add((char)output[i]);    //printing
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}