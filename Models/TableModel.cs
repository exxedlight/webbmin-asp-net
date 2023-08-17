namespace WebApplication1.Models
{
    public class TableModel
    {
        //Fields
        public int Size { get; set; } = 0;
        public string Table { get; set; } = "";
        public string Vector { get; set; } = "";
        public string CalcResult { get; set; } = "";


        //Methods
        private String Combine(String m, String n)
        {
            int a = m.Length;
            string c = "";
            int count = 0;

            for (int i = 0; i < a; i++)
            {
                if (m[i] == n[i]) c += m[i];
                else
                {
                    c += '-';
                    count++;
                }
            }

            if (count > 1) return "";
            else return c;

        }

        //gets data in format [0000 0001 0010 0011 ...]
        public String find_minterms(List<String> data)
        {
            String result = "";

            List<String> newlist = data;

            int size = newlist.Count;
            List<string> imp = new List<string>(), im = new List<string>(), im2 = new List<string>();
            int m = 0;
            int[] mark = new int[size];
            for (int i = 0; i < mark.Length; i++)
            {
                mark[i] = 0;
            }


            for(int i = 0; i < size; i++)
            {
                for(int j = i+1; j <size; j++)
                {
                    String c = Combine(newlist[i], newlist[j]);
                    if (c != "")
                    {
                        im.Add(c);
                        mark[i] = 1; mark[j] = 1;
                    }
                    else continue;
                }
            }

            int[] mark2 = new int[im.Count];
            for (int i = 0; i < mark2.Length; i++) mark2[i] = 0;

            for (int i = 0; i < im.Count; i++)
            {
                for(int j = i+1; j < im.Count; j++)
                {
                    if(i != j && mark2[j] == 0)
                    {
                        if (im[i] == im[j]) mark2[j] = 1;
                    }
                }
            }

            for(int i = 0; i < im.Count; i++)
            {
                if (mark2[i]==0) im2.Add(im[i]);
            }

            for(int i = 0; i < size; i++)
            {
                if (mark[i] == 0)
                {
                    imp.Add(newlist[i]);
                    m++;
                }
            }

            if (m == size || size == 1)
            {
                foreach(String a in imp) result += a + "\n";
                return result;
            }
            else
            {
                foreach (String a in imp) result += a + " ";
                return result + find_minterms(im2);
            }
        }
    }
}
