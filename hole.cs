using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_2__Memory_Allocation
{

    public class hole
    {
        public int start;
        public int size;
        public bool gap;
        public bool full;
        public bool was_rest;
        public int process_size;
        public string process_name;

        public hole()
        {
            start = 0;
            size = 0;
            process_size = 0;
            full = false;
            gap = false;
            was_rest = false;
        }
        public hole(int start, int size)
        {
            this.start = start;
            this.size = size;
            process_size = 0;
            full = false;
        }
        public hole(int start, int size, Boolean gap)
        {
            this.start = start;
            this.size = size;
            this.gap = gap;
            process_size = 0;
            full = false;
        }

        public void copy(hole h)
        {
            start = h.start;
            size = h.size;
            full = h.full;
        }
    }
}
