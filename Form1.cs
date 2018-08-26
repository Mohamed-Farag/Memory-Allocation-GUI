using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_2__Memory_Allocation
{

    public partial class Form1 : Form
    {

        //hole[] ArrayOfHoles = new hole[dataGridView1.Rows.Count];          //Declarion of Array Of Holes
        List<hole> ArrayOfHoles = new List<hole>();                          //Declarion of List Of Holes
        List<gap>  ArrayOfgaps  = new List<gap>();                            //Declarion of List Of gaps

        string Name_OF_Process;
        int Size_OF_Process;
        GroupBox Memory_GroupBox = new GroupBox();
      //  List<CheckBox> state_of_hole = new List<CheckBox>();  


        public Form1()
        {
            InitializeComponent();
      
        }


        public void button1_Click(object sender, EventArgs e)                      // OK1
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    state_of_hole.Add(new CheckBox());
            //    state_of_hole[i].CheckedChanged += new System.EventHandler(checkBox1_Click);
            //    //state_of_hole[i].Checked = true;
            //}

            dataGridView1.RowCount = Convert.ToInt32(textBox_noOfHoles.Text);      //To Get no of rows of dataGridView
            dataGridView1.ColumnCount = 2;
            dataGridView1.Show();                                                  //To Show dataGrid
            OK2_Button.Show();                                                     //To show OK2

            /* for loop for adding items in List and creating it*/

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ArrayOfHoles.Add(new hole());
            }

            for (int i = 0; i < dataGridView1.Rows.Count +1 ; i++)
            {
                ArrayOfgaps.Add(new gap());
            }


        }
        public void Drawing(List<hole> ArrayOfHoles, List<gap> ArrayOfgaps, Boolean first)
        {

            Memory_GroupBox.Controls.Clear();

            //Memory_GroupBox.ForeColor  = Color.LightBlue;

            Memory_GroupBox.AutoSize = false;
            Memory_GroupBox.Location = new System.Drawing.Point(400, 10);
            Memory_GroupBox.Size = new System.Drawing.Size(300, Convert.ToInt32(textBox_SizeOfMemory.Text) + 100);
           // Memory_GroupBox.BorderColor = Color.Red;  
            Memory_GroupBox.Anchor = AnchorStyles.Top |
                      // AnchorStyles.Bottom |
                       AnchorStyles.Left;
                       //AnchorStyles.Right;
          //  Memory_GroupBox. = ContentAlignment.MiddleRight;

            this.Controls.Add(Memory_GroupBox);

            

            /* MEM */
            Label MEM = new Label();
            MEM.Text = "Memory";
            MEM.Left = 115;
            MEM.Top = 17;
            MEM.Font = new Font("Arial", 15, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            MEM.ForeColor = System.Drawing.Color.Red;
            Memory_GroupBox.Controls.Add(MEM);



            if (first == true)
          {
            /* Taking Values From DataGridView and filling the ArrayOfHoles */

            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                ArrayOfHoles[rows].start = Convert.ToInt32(dataGridView1.Rows[rows].Cells[0].Value) + 50;    // al 50 deh 3shan al rsma (al location bta3 bdayt al memory)
                ArrayOfHoles[rows].size = Convert.ToInt32(dataGridView1.Rows[rows].Cells[1].Value);
            }
            ArrayOfHoles.Sort((x, y) => x.start.CompareTo(y.start));
                if(ArrayOfHoles[dataGridView1.Rows.Count - 1].start - 50+ ArrayOfHoles[dataGridView1.Rows.Count - 1].size > Convert.ToInt32(textBox_SizeOfMemory.Text))
                {
                    string message = "Oh , You Have Exceed The Size Of The Memory";
                    string caption = "Warning !";
                    System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    System.Windows.Forms.MessageBox.Show(message, caption, buttons);
                    Close();
                }
          }
            /* Aloocating Process into Memory */

            int sizeOfMemoryForDrawing = Convert.ToInt32(textBox_SizeOfMemory.Text) + 50;
            int current = 50;                                // al 50 deh 3shan al rsma (al location bta3 bdayt al memory)
            int j = 0;                                       // dah by3d 3la al holes wl processes bs
            int current_adeem = current;
            int counter= 0;                                  // dah by3d 3la al holes wl processes wl gaps   .... 3'yrt al klam dah b7ys y3d al gaps bs
            Boolean process_after_process = false;           // dah 3shan lw 2 process d5lo wra b3d yrsm 5t ma bynhm

            while (current < Convert.ToInt32(textBox_SizeOfMemory.Text) + 50)
            {
                if (j < ArrayOfHoles.Count)            // al shart dah 3shan lw al holes 5lst w lsa fe mkan f al memory 
                {
                    if (current == ArrayOfHoles[j].start)                   // lw hole hyd5l hna (7aga mwgoda fe al array)
                    {

                        if (process_after_process == true)                             // hna an bs 3ays arsm 5t been kl atneen process
                        {
                            PictureBox fasl_been_al_atneen_processes = new PictureBox();
                            fasl_been_al_atneen_processes.AutoSize = false;                    // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                            fasl_been_al_atneen_processes.Location = new System.Drawing.Point(60, current);

                            fasl_been_al_atneen_processes.Size = new System.Drawing.Size(200, 1);
                            fasl_been_al_atneen_processes.BackColor = System.Drawing.Color.Black;
                            Memory_GroupBox.Controls.Add(fasl_been_al_atneen_processes);

                            current = ArrayOfHoles[j].start;             //updeating current
                        }

                        Label no_current = new Label();     
                        no_current.AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                        no_current.TextAlign = ContentAlignment.MiddleRight;
                        no_current.Location = new System.Drawing.Point(30, current - 10);
                        no_current.Size = new System.Drawing.Size(30, 16);
                        no_current.Font = new Font("Arial",7, FontStyle.Bold);
                        current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
                        no_current.Text = Convert.ToString(current);
                        current += 50;
                        Memory_GroupBox.Controls.Add(no_current);


                        Label process = new Label();                 // al label dah bta3 al process aw al hole (lsa ht2kd)
                        process.AutoSize = false;                    // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                        process.Text = ArrayOfHoles[j].process_name;
                        process.Location = new System.Drawing.Point(60, current);
                        process.Size = new System.Drawing.Size(200, ArrayOfHoles[j].size);
                        process.TextAlign = ContentAlignment.MiddleCenter;
                        //process.Font = new Font(process.Font.FontFamily, process.Font.Size - 0.5f, process.Font.Style);
                        process.Font = new Font("Arial", (ArrayOfHoles[j].size)/3, FontStyle.Regular);
                        process.ForeColor = System.Drawing.Color.DarkOrange;           //al Brown nw3n ma 7lw
                        if (ArrayOfHoles[j].full == true)             //deh process
                        {
                            process.BackColor = System.Drawing.Color.Green;
                            //process.BackColor = System.Drawing.Color.Blue;
                            //state_of_hole[counter] = new CheckBox();
                            //state_of_hole[counter].Checked = true;
                            //state_of_hole[counter].AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                            //// state_of_hole.TextAlign = ContentAlignment.MiddleRight;
                            //state_of_hole[counter].Location = new System.Drawing.Point(260, current - 4);
                            //state_of_hole[counter].Size = new System.Drawing.Size(100, 20);
                            //current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
                            //state_of_hole[counter].Text = "click to free";
                            //current += 50;
                            //Memory_GroupBox.Controls.Add(state_of_hole[counter]);
                        }
                        else
                        {
                            process.BackColor = System.Drawing.Color.White;
                        }
                        Memory_GroupBox.Controls.Add(process);

                        current += ArrayOfHoles[j].size;             //updeating current
                        j++;                                         //updating j
                        //counter++;                                   //updating al counter

                        process_after_process = true;               
                    }

                    else                                              // lw filled hyd5l hna
                    {
                        //state_of_hole[counter] = new CheckBox();
                        //state_of_hole[counter].Checked = true;
                        //state_of_hole[counter].AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                        //// state_of_hole.TextAlign = ContentAlignment.MiddleRight;
                        //state_of_hole[counter].Location = new System.Drawing.Point(260, current - 4);
                        //state_of_hole[counter].Size = new System.Drawing.Size(100, 20);
                        //current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
                        //state_of_hole[counter].Text = "click to free";
                        //current += 50;
                        //Memory_GroupBox.Controls.Add(state_of_hole[counter]);

                        Label no_current = new Label();
                        no_current.AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                        no_current.TextAlign = ContentAlignment.MiddleRight;
                        no_current.Location = new System.Drawing.Point(30, current - 10);
                        no_current.Size = new System.Drawing.Size(30, 16);
                        no_current.Font = new Font("Arial", 7, FontStyle.Bold);
                        current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
                        no_current.Text = Convert.ToString(current);
                        current += 50;
                        Memory_GroupBox.Controls.Add(no_current);

                        PictureBox process = new PictureBox();
                        process.AutoSize = false;                    // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                        process.Location = new System.Drawing.Point(60, current);

                        process.Size = new System.Drawing.Size(200, ArrayOfHoles[j].start - current);
                        process.BackColor = System.Drawing.Color.Gray;
                        Memory_GroupBox.Controls.Add(process);
                        ArrayOfgaps[counter].start = current;
                        current_adeem = current;
                        current = ArrayOfHoles[j].start;             //updeating current
                        ArrayOfgaps[counter].size = current - current_adeem;

                        process_after_process = false;

                        counter++;                                   //updating al counter
                    }
                }
                else
                {
                    //state_of_hole[counter] = new CheckBox();
                    //state_of_hole[counter].Checked = true;
                    //state_of_hole[counter].AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                    //// state_of_hole.TextAlign = ContentAlignment.MiddleRight;
                    //state_of_hole[counter].Location = new System.Drawing.Point(260, current - 4);
                    //state_of_hole[counter].Size = new System.Drawing.Size(100, 20);
                    //current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
                    //state_of_hole[counter].Text = "click to free";
                    //current += 50;
                    //Memory_GroupBox.Controls.Add(state_of_hole[counter]);


                    Label no_current = new Label();
                    no_current.AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                    no_current.TextAlign = ContentAlignment.MiddleRight;
                    no_current.Location = new System.Drawing.Point(30, current - 10);
                    no_current.Size = new System.Drawing.Size(30, 16);
                    no_current.Font = new Font("Arial", 7, FontStyle.Bold);
                    current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
                    no_current.Text = Convert.ToString(current);
                    current += 50;
                    Memory_GroupBox.Controls.Add(no_current);

                    PictureBox process = new PictureBox();
                    process.AutoSize = false;                    // al amr dah by5lik t2dr tt7km fe al height of the TextBox
                    process.Location = new System.Drawing.Point(60, current);

                    process.Size = new System.Drawing.Size(200, sizeOfMemoryForDrawing - current);
                    process.BackColor = System.Drawing.Color.Gray;
                    Memory_GroupBox.Controls.Add(process);
                    ArrayOfgaps[counter].start = current;
                    ArrayOfgaps[counter].size = sizeOfMemoryForDrawing - current;
                    current = sizeOfMemoryForDrawing;             //updeating current       (msh mot2kd mnha)
                    counter++;                                    //updating al counter

                }
            }



                          /* al kam satr dol al hadf mnhm rsm a5r rkm 5als fe al memory la aktr ela a2l*/

            current = sizeOfMemoryForDrawing;             //updeating current
            Label The_Last_no_current = new Label();
            The_Last_no_current.AutoSize = false;        // al amr dah by5lik t2dr tt7km fe al height of the TextBox
            The_Last_no_current.TextAlign = ContentAlignment.MiddleRight;
            The_Last_no_current.Location = new System.Drawing.Point(30, current - 13);
            The_Last_no_current.Size = new System.Drawing.Size(30, 16);
            The_Last_no_current.Font = new Font("Arial", 7, FontStyle.Bold);
            current -= 50;                                        // bn2s al current 3shan ytb3 al kyma s7 w b3dden bzwdh tany
            The_Last_no_current.Text = Convert.ToString(current);
            current += 50;
            Memory_GroupBox.Controls.Add(The_Last_no_current);
            // Memory_GroupBox.Controls.Clear();
            textbox_NameOfProcess.Clear();
            textbox_SizeOfProcess.Clear();

          //  textbox_NameOfProcess.Text.Remove(textbox_NameOfProcess.SelectionStart,3);
          //  textbox_SizeOfProcess.Text.Remove(textbox_SizeOfProcess.SelectionStart,3);
        }

     

        // Set Font property and then add a new Label.


        private void button1_Click_1(object sender, EventArgs e)        // Allocate
        {
          

            if(First_Fit.Checked == false &&Best_Fit.Checked == false &&Worst_Fit.Checked == false)
            {
                string message = "Please choose the technique";
                string caption = "missing data !";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                System.Windows.Forms.MessageBox.Show(message, caption, buttons);
            }

            else if (textbox_NameOfProcess.Text == "" && textbox_SizeOfProcess.Text == "")
            {
                string message = "Please Enter The name of the process you want to allocate and its size";
                string caption = "missing data !";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                System.Windows.Forms.MessageBox.Show(message, caption, buttons);
            }
            else if(textbox_NameOfProcess.Text == "")
            {
                string message = "Please Enter The name of process";
                string caption = "missing data !";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                System.Windows.Forms.MessageBox.Show(message, caption, buttons);
            }

            else if (textbox_SizeOfProcess.Text == "")
            {
                string message = "Please Enter The size of process  you want to allocate";
                string caption = "missing data !";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                System.Windows.Forms.MessageBox.Show(message, caption, buttons);
            }

            else
            {

                Name_OF_Process = textbox_NameOfProcess.Text;
                Size_OF_Process = Convert.ToInt32(textbox_SizeOfProcess.Text);

                if (First_Fit.Checked)
                {
                    allocate_first_fit.run(ArrayOfHoles, Size_OF_Process, Name_OF_Process);
                    Drawing(ArrayOfHoles, ArrayOfgaps, false);
                }
                else if (Best_Fit.Checked)
                {
                    allocate_best_fit.run(ArrayOfHoles, Size_OF_Process, Name_OF_Process);
                    Drawing(ArrayOfHoles, ArrayOfgaps, false);
                }
                else if (Worst_Fit.Checked)
                {
                    allocate_worst_fit.run(ArrayOfHoles, Size_OF_Process, Name_OF_Process);
                    Drawing(ArrayOfHoles, ArrayOfgaps, false);
                }

            }

        }

     

       

        private void button1_Click_2(object sender, EventArgs e)                   //OK2
        {
            Drawing(ArrayOfHoles, ArrayOfgaps, true);

            Allocate.Show();
            label_NameOfProcess.Show();
            label_SizeOfProcess.Show();
            textbox_NameOfProcess.Show();
            textbox_SizeOfProcess.Show();
            First_Fit.Show();
            Best_Fit.Show();
            Worst_Fit.Show();
            label_Deallocate.Show();
            textBox_Deallocate.Show();
            Deallocate.Show();
        }

        private void textbox_SizeOfProcess_TextChanged(object sender, EventArgs e)
        {

        }

        private void Deallocate_Click(object sender, EventArgs e)                        //Deallocate
        {
            int size = 0;
            int i = 0;
            for ( i = 0; i < ArrayOfgaps.Count; i++)
            {
                if(ArrayOfgaps[i].start == Convert.ToInt32(textBox_Deallocate.Text) +50)
                {
                    size = ArrayOfgaps[i].size;
                    break;
                }
                
            }

            if(i != ArrayOfgaps.Count)
            {
                ArrayOfgaps.RemoveAt(i);
            }

            deallocate.run(ArrayOfHoles, Convert.ToInt32(textBox_Deallocate.Text) +50, size);              //al 50 de 3shan al rsm

            textBox_Deallocate.Clear();

            Drawing(ArrayOfHoles, ArrayOfgaps, false);
        }

        //private void checkBox1_Click(object sender, System.EventArgs e)                // check
        //{
        //  //  for (int i = 0; i < 3; i++)
        // //   {
        //    if (state_of_hole[0].Checked == false || state_of_hole[1].Checked == false)
        //    {
        //        string message = "checkBox is checked";
        //        string caption = "Can't allocate !";
        //        System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
        //        System.Windows.Forms.MessageBox.Show(message, caption, buttons);

        //    }
                
        //  //  }
           
        //}
 
    }
}

// dah al code al adeem 
// MemoryBlocks = new TextBox[Convert.ToInt32(textBox_of_no_of_Blocks.Text)];      // hna b7dd 3dd al blocks bta3t al memory
// this.Controls.Clear();

// FontFamily family = new FontFamily("Times New Roman");

// Font font = new Font(family, 16.0f,
//     FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

// // Set Font property.
// this.Font = font;
// this.Controls.Add( new Label() { Text = "Memory", Width = 250 ,Left = 110,Top = 20});
// this.Size = new Size(335, 500);                        //size of the form itself





// int sum = 50;
// for (int i = 0; i < Convert.ToInt32(textBox_of_no_of_Blocks.Text); i++)
//{
//    if (i > 0)
//    {
//        sum += Convert.ToInt32(no_of_blocks[i - 1].Text)/2;     // msh hynfz al satr dah lw i = 0  , al 1 dah scale 3san n minmize al donia shwya
//    }

//     MemoryBlocks[i] = new TextBox();
//     this.MemoryBlocks[i].AutoSize = false;               // al amr dah by5lik t2dr tt7km fe al height of the TextBox
//     this.MemoryBlocks[i].Size = new System.Drawing.Size(200,  Convert.ToInt32(no_of_blocks[i].Text)/2);      // awl rkm hwa al width wl tany hwa al height
//     MemoryBlocks[i].Left = 60 ;
//     MemoryBlocks[i].Top = sum;

//    // this.Controls.Add(MemoryBlocks[i]);
// }