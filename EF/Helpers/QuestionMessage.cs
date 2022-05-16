using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Helpers
{
    public static class QuestionMessage
    {
        public static string Question(string Message)
        {
            Console.Write(Message + " ");
            string answer = Console.ReadLine() ?? "";
            
            return answer;
        }
    }
}
