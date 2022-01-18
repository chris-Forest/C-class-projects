using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace chris_ica16
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine(ToTable());//ToTable(arr{i))
            Console.ReadKey();            
        }

        //used a helper method to make circuit
        static private string ToTable()//Gate theGates?
        {            
            StringBuilder TruthTable = new StringBuilder();//logicGates.Name
            TruthTable.AppendLine("A B C D O").ToString();

            //nested loops itterate thruogh all possible inputs
            for (int A = 0; A < 2; A++)
            {
                for (int B = 0; B < 2; B++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        for (int d = 0; d < 2; d++)
                        {
                            TruthTable.Append($"{A} ").ToString();
                            TruthTable.Append($"{B} ").ToString();
                            TruthTable.Append($"{c} ").ToString();
                            TruthTable.Append($"{d} ").ToString();
                            TruthTable.AppendLine($"{doLogic(A, B, c, d)}").ToString();// appendline at last output
                        }
                    }                    
                }
            }

            //return table AS A STRING
            return TruthTable.ToString();
        }

        //helper method to run the logic for a circuit diagram
        static private int doLogic(int a,int b,int c,int d )
        {
            //gate array ffrom circut diagram
            Gate[] logic =
            {
                new AndGate(),
                new OrGate(),
                new NandGate(),
                new XorGate(),
                new NandGate(),
                new OrGate(),
                new AndGate(),
                new XorGate(),
                new AndGate(),
                new OrGate()
            };

            int output=0;

            for (int i = 0; i < logic.Length; i++)
            {
                //gate 1 and gate
                if(i==0)
                {
                    logic[0].Set(a, a);
                    logic[0].latch();
                }
                //gate 2 or gate
                if (i == 1)
                {
                    logic[1].Set(a, b);
                    logic[1].latch();
                }
                //Gate 3 nand gate
                if (i == 2)
                {
                    logic[2].Set(b, c);
                    logic[2].latch();
                }
                //gate 4 xor gate
                if (i == 3)
                {
                    logic[3].Set(Convert.ToInt32(logic[2].output), c);
                    logic[3].latch();
                }
                //gate 5 nand gate
                if (i == 4)
                {
                    logic[4].Set(Convert.ToInt32(logic[0].output), Convert.ToInt32(logic[1].output));
                    logic[4].latch();
                }
                //gate 6 or gate
                if (i == 5)
                {
                    logic[5].Set(Convert.ToInt32(logic[0].output), Convert.ToInt32(logic[1].output));
                    logic[5].latch();
                }
                //gate 7 and gate
                if (i == 6)
                {
                    logic[6].Set(Convert.ToInt32(logic[1].output), Convert.ToInt32(logic[3].output));
                    logic[6].latch();
                }
                //gate 8 xor gate
                if (i == 7)
                {
                    logic[7].Set(Convert.ToInt32(logic[3].output), d);
                    logic[7].latch();
                }
                //gate 9 and gate
                if (i == 8)
                {
                    logic[8].Set(Convert.ToInt32(logic[5].output), Convert.ToInt32(logic[6].output));
                    logic[8].latch();
                }
                //gate 10 or gate
                if (i == 9)
                {
                    logic[9].Set(Convert.ToInt32(logic[8].output), Convert.ToInt32(logic[7].output));
                    logic[9].latch();
                }
            }
            //retuen truth table of circuit form pdf
            return output = Convert.ToInt32(logic[9].output);
        }
    }
}
