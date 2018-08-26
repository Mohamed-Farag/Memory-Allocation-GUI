using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_2__Memory_Allocation
{
    public class deallocate
    {

        public static void run(List<hole> location, int start, int size)
        {
            int i = 0;
            for ( i = 0; i < location.Count; i++)
            {
                // in case process already exists in the list
                if (location[i].start == start &&  location[i].full == true)
                {
                    location[i].full = false;
                    //location[i].process_size = 0;
                    location[i].process_name = "";
                    if (i != location.Count - 1 && location[i + 1].full == false && location[i + 1].was_rest == true)
                    {
                        location[i].size += location[i + 1].size;
                        location.RemoveAt(i + 1);
                    }


                    if ((i != 0 && location[i - 1].full == false && location[i].was_rest == true))
                    {
                        location[i - 1].size += location[i].size;
                        location.RemoveAt(i);
                    }
                    break;

                }

                // in case I didn't find it in the list so it's a gap
               else if (size>0)
                {
                    location.Add(new hole(start, size));
                    location.Sort((x, y) => x.start.CompareTo(y.start));
                    break;

                }

            }
            if(i == location.Count)
            {
                string message = "Sorry, You have Entered a Wrong Starting address, Please Try again";
                string caption = "Wrong !";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                System.Windows.Forms.MessageBox.Show(message, caption, buttons);

            }
        }
    }
}