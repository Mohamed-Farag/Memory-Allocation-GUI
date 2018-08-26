using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_2__Memory_Allocation
{

    public class allocate_first_fit
    {

        public static void run(List<hole> location, int process_size, string process_name)
        {
            //sorting location according to its start
            location.Sort((x, y) => x.start.CompareTo(y.start));

            //loop on the location to find the first one to fit


            for (int i = 0; i < location.Count; i++)
            {
                if (location[i].size >= process_size && location[i].full != true)
                {
                    location[i].full = true;
                    location[i].process_size = process_size;
                    location[i].process_name = process_name;
                    int rest = location[i].size - location[i].process_size;
                    int start = location[i].start + location[i].process_size;
                    location[i].size = location[i].process_size;
                    if (rest != 0)
                    {
                        hole temporary = new hole(start, rest);
                        temporary.was_rest = true;
                        location.Add(temporary);

                    }
                    break;
                }
                else if (i == location.Count - 1)
                {
                    string message = "Unfortunately , we couldn't find a proper place for the process.Try to allocate another one";
                    string caption = "Can't allocate !";
                    System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.OK;
                    System.Windows.Forms.MessageBox.Show(message, caption, buttons);

                }

            }

            location.Sort((x, y) => x.start.CompareTo(y.start));

        }
    }
}