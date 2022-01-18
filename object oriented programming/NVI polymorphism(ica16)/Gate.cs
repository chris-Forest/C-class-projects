using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chris_ica16
{
    abstract class Gate
    {
        private protected bool _inA;
        public bool inA { get { return _inA; } }
        private protected bool _inB;
        public bool inB { get { return _inB; } }
        protected bool _output;
        public bool output { get { return _output; } }

        public void Set(int a, int b)
        {
            if (a != 0)
                _inA = true;
            else
                _inA = false;
            if (b !=0)
                _inB = true;
           else
                _inB = false;
        }

        //Add a public method void Latch(), and its matching abstract method
        public void latch() 
        {
            latch1Core();
        }

        /// <summary>
        /// matching abstract method
        /// </summary>
        public abstract void latch1Core();

        //Add a public property string Name, and its matching abstract property // getters only
        public string Name { get { return coreName; } }
        public abstract string coreName { get; }
    }

    /// <summary>
    /// ovride method to set output form logic action
    /// as well as logic name
    /// </summary>
    class NandGate: Gate
    {
        public override void latch1Core()
        {
            _output = !(_inA&_inB);
        }
        public override string coreName => "Nand";
    }

    /// <summary>
    /// ovride method to set output form logic action
    /// as well as logic name
    /// </summary>
    class OrGate :Gate
    {
        public override void latch1Core()
        {
            _output = _inA | _inB;
        }
        public override string coreName => "OR";
    }

    /// <summary>
    /// ovride method to set output form logic action
    /// as well as logic name
    /// </summary>
    class XorGate :Gate
    {
        public override void latch1Core()
        {
            _output = _inA ^ _inB;
        }
        public override string coreName => "XOR";
    }

    /// <summary>
    /// ovride method to set output form logic action
    /// as well as logic name
    /// </summary>
    class AndGate :NandGate
    {        
        public override void latch1Core()
        {
            base.latch1Core();
            _output = !_output;
        }
        public override string coreName => "And";
    }
}
