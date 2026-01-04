// StringBuilder

using System.Text;

namespace Lesson_8_Strings_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("abc ");
            sb.Append("def ");
            sb.Append("ghi ");
            sb.Append("jkl ");
            sb.Append("mno ");
            sb.Append("pqr ");
            sb.Append("stu ");
            sb.Append("wxyz ");
            sb.AppendLine(" "); //\n
            sb.Append("121321");
            
            string str1 = sb.ToString();
            Console.WriteLine(str1);
            
            sb.Clear();

            for (int i = 0; i < 5; i++)
            {
                sb.Append("Hello "); 
                sb.Append(i);
                sb.AppendLine("!");
            }
            
            string str2 = sb.ToString();
            Console.WriteLine(str2);
            
            
            Console.ReadKey();
        }
    }
}