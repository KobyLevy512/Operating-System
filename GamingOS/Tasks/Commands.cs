
using System.IO;

namespace GamingOS.Tasks
{
    //MOVS OPERATIONS
    //--------------------------------------------
    //0 - mov byte reg, const: next byte is which register and the next is constant value
    //1 - mov byte reg, mem: next byte is which register and the 4 next is the memory address
    //2 - mov byte reg, reg: next byte is which register and the next is the other register
    //3 - mov byte mem, const: next 4 bytes are memory address and the next is the constant
    //4 - mov byte mem, mem:next 4 bytes are memory address and the 4 next is the other memory address
    //5 - mov byte mem, reg:next 4 bytes are memory address and the next is the register

    //6  - mov word reg, const: next byte is which register and the next 2 is constant value
    //7  - mov word reg, mem: next byte is which register and the 4 next is the memory address
    //8  - mov word reg, reg: next byte is which register and the next is the other register
    //9  - mov word mem, const: next 4 bytes are memory address and the 2 next is the constant
    //10 - mov word mem, mem:next 4 bytes are memory address and the 4 next is the other memory address
    //11 - mov word mem, reg:next 4 bytes are memory address and the next is the register

    //12 - mov dword reg, const: next byte is which register and the next 4 is constant value
    //13 - mov dword reg, mem: next byte is which register and the 4 next is the memory address
    //14 - mov dword reg, reg: next byte is which register and the next is the other register
    //15 - mov dword mem, const: next 4 bytes are memory address and the 4 next is the constant
    //16 - mov dword mem, mem:next 4 bytes are memory address and the 4 next is the other memory address
    //17 - mov dword mem, reg:next 4 bytes are memory address and the next is the register

    //18 - mov qword reg, const: next byte is which register and the next 8 is constant value
    //19 - mov qword reg, mem: next byte is which register and the 4 next is the memory address
    //20 - mov qword reg, reg: next byte is which register and the next is the other register
    //21 - mov qword mem, const: next 4 bytes are memory address and the 8 next is the constant
    //22 - mov qword mem, mem:next 4 bytes are memory address and the 4 next is the other memory address
    //23 - mov qword mem, reg:next 4 bytes are memory address and the next is the register

    //24 - mov byte *reg, const: next byte is which register and the next is constant value
    //25 - mov byte *reg, mem: next byte is which register and the 4 next is the memory address
    //26 - mov byte *reg, reg: next byte is which register and the next is the other register
    //27 - mov byte *reg, *reg: next byte is which register and the next is the other register
    //28 - mov byte  reg, *reg: next byte is which register and the next is the other register

    //29 - mov word *reg, const: next byte is which register and the next 2 is constant value
    //30 - mov word *reg, mem: next byte is which register and the 4 next is the memory address
    //31 - mov word *reg, reg: next byte is which register and the next is the other register
    //32 - mov word *reg, *reg: next byte is which register and the next is the other register
    //33 - mov word  reg, *reg: next byte is which register and the next is the other register

    //34 - mov dword *reg, const: next byte is which register and the next 4 is constant value
    //35 - mov dword *reg, mem: next byte is which register and the 4 next is the memory address
    //36 - mov dword *reg, reg: next byte is which register and the next is the other register
    //37 - mov dword *reg, *reg: next byte is which register and the next is the other register
    //38 - mov dword  reg, *reg: next byte is which register and the next is the other register

    //39 - mov qword *reg, const: next byte is which register and the next 8 is constant value
    //40 - mov qword *reg, mem: next byte is which register and the 4 next is the memory address
    //41 - mov qword *reg, reg: next byte is which register and the next is the other register
    //42 - mov qword *reg, *reg: next byte is which register and the next is the other register
    //43 - mov qword  reg, *reg: next byte is which register and the next is the other register
    //--------------------------------------------



    // LEA OPERATIONS
    //--------------------------------------------
    //44 - lea reg, mem : next byte is which register and the 4 next is the memory address
    //45 - lea reg, reg : next byte is which register and the  next is the other reg
    //--------------------------------------------


    //  MATHS OPERATIONS
    //--------------------------------------------
    //46 - add byte reg, const : next byte is which register and the next is the constant value
    //47 - add byte reg, mem : next byte is which register and the next 4 is the memory address
    //48 - add byte reg, reg : next byte is which register and the next is the other register

    //49 - add word reg, const : next byte is which register and the next 2 is the constant value
    //50 - add word reg, mem : next byte is which register and the next 4 is the memory address
    //51 - add word reg, reg : next byte is which register and the next is the other register

    //52 - add dword reg, const : next byte is which register and the next 4 is the constant value
    //53 - add dword reg, mem : next byte is which register and the next 4 is the memory address
    //54 - add dword reg, reg : next byte is which register and the next is the other register

    //55 - add qword reg, const : next byte is which register and the next 8 is the constant value
    //56 - add qword reg, mem : next byte is which register and the next 4 is the memory address
    //57 - add qword reg, reg : next byte is which register and the next is the other register


    //58 - sub byte reg, const : next byte is which register and the next is the constant value
    //59 - sub byte reg, mem : next byte is which register and the next 4 is the memory address
    //60 - sub byte reg, reg : next byte is which register and the next is the other register

    //61 - sub word reg, const : next byte is which register and the next 2 is the constant value
    //62 - sub word reg, mem : next byte is which register and the next 4 is the memory address
    //63 - sub word reg, reg : next byte is which register and the next is the other register

    //64 - sub dword reg, const : next byte is which register and the next 4 is the constant value
    //65 - sub dword reg, mem : next byte is which register and the next 4 is the memory address
    //66 - sub dword reg, reg : next byte is which register and the next is the other register

    //67 - sub qword reg, const : next byte is which register and the next 8 is the constant value
    //68 - sub qword reg, mem : next byte is which register and the next 4 is the memory address
    //69 - sub qword reg, reg : next byte is which register and the next is the other register


    //70 - mul byte reg, const : next byte is which register and the next is the constant value
    //71 - mul byte reg, mem : next byte is which register and the next 4 is the memory address
    //72 - mul byte reg, reg : next byte is which register and the next is the other register

    //73 - mul word reg, const : next byte is which register and the next 2 is the constant value
    //74 - mul word reg, mem : next byte is which register and the next 4 is the memory address
    //75 - mul word reg, reg : next byte is which register and the next is the other register

    //76 - mul dword reg, const : next byte is which register and the next 4 is the constant value
    //77 - mul dword reg, mem : next byte is which register and the next 4 is the memory address
    //78 - mul dword reg, reg : next byte is which register and the next is the other register

    //79 - mul qword reg, const : next byte is which register and the next 8 is the constant value
    //80 - mul qword reg, mem : next byte is which register and the next 4 is the memory address
    //81 - mul qword reg, reg : next byte is which register and the next is the other register


    //82 - div byte reg, const : next byte is which register and the next is the constant value
    //83 - div byte reg, mem : next byte is which register and the next 4 is the memory address
    //84 - div byte reg, reg : next byte is which register and the next is the other register

    //85 - div word reg, const : next byte is which register and the next 2 is the constant value
    //86 - div word reg, mem : next byte is which register and the next 4 is the memory address
    //87 - div word reg, reg : next byte is which register and the next is the other register

    //88 - div dword reg, const : next byte is which register and the next 4 is the constant value
    //89 - div dword reg, mem : next byte is which register and the next 4 is the memory address
    //90 - div dword reg, reg : next byte is which register and the next is the other register

    //91 - div qword reg, const : next byte is which register and the next 8 is the constant value
    //92 - div qword reg, mem : next byte is which register and the next 4 is the memory address
    //93 - div qword reg, reg : next byte is which register and the next is the other register
    //--------------------------------------------


    //CMP OPERATIONS
    //--------------------------------------------
    //94 - cmp byte reg, const : next byte is which register and the next is the constant value
    //95 - cmp byte reg, mem : next byte is which register and the next 4 is the memory address
    //96 - cmp byte reg, reg : next byte is which register and the next is the other register
    //97 - cmp byte mem, const : next 4 bytes is the memory address and the next is the constant value
    //98 - cmp byte mem, mem : next 4 bytes is the memory address and the next 4 is the other memory address
    //99 - cmp byte mem, reg : next 4 bytes is the memory address and the next is the other register

    //100 - cmp word reg, const : next byte is which register and the next 2 is the constant value
    //101 - cmp word reg, mem : next byte is which register and the next 4 is the memory address
    //102 - cmp word reg, reg : next byte is which register and the next is the other register
    //103 - cmp word mem, const : next 4 bytes is the memory address and the next 2 is the constant value
    //104 - cmp word mem, mem : next 4 bytes is the memory address and the next 4 is the other memory address
    //105 - cmp word mem, reg : next 4 bytes is the memory address and the next is the other register

    //106 - cmp dword reg, const : next byte is which register and the next 4 is the constant value
    //107 - cmp dword reg, mem : next byte is which register and the next 4 is the memory address
    //108 - cmp dword reg, reg : next byte is which register and the next is the other register
    //109 - cmp dword mem, const : next 4 bytes is the memory address and the next 4 is the constant value
    //110 - cmp dword mem, mem : next 4 bytes is the memory address and the next 4 is the other memory address
    //111 - cmp dword mem, reg : next 4 bytes is the memory address and the next is the other register

    //112 - cmp qword reg, const : next byte is which register and the next 8 is the constant value
    //113 - cmp qword reg, mem : next byte is which register and the next 4 is the memory address
    //114 - cmp qword reg, reg : next byte is which register and the next is the other register
    //115 - cmp qword mem, const : next 4 bytes is the memory address and the next 8 is the constant value
    //116 - cmp qword mem, mem : next 4 bytes is the memory address and the next 4 is the other memory address
    //117 - cmp qword mem, reg : next 4 bytes is the memory address and the next is the other register
    //--------------------------------------------

    //JMP OPERATIONS
    //--------------------------------------------
    //118 - jmp label : next 4 bytes is the code line to jump to
    //119 - je label : next 4 bytes is the code line to jump to
    //120 - jne label : next 4 bytes is the code line to jump to
    //121 - jg label : next 4 bytes is the code line to jump to
    //122 - jge label : next 4 bytes is the code line to jump to
    //123 - jl label : next 4 bytes is the code line to jump to
    //124 - jle label : next 4 bytes is the code line to jump to
    //--------------------------------------------


    //BITWISE OPERATIONS
    //--------------------------------------------
    //125 - or byte reg, const : next byte is which register and the next is the constant value
    //126 - or byte reg, mem : next byte is which register and the next 4 is the memory address
    //127 - or byte reg, reg : next byte is which register and the next is the other register

    //128 - or word reg, const : next byte is which register and the next 2 is the constant value
    //129 - or word reg, mem : next byte is which register and the next 4 is the memory address
    //130 - or word reg, reg : next byte is which register and the next is the other register

    //131 - or dword reg, const : next byte is which register and the next 4 is the constant value
    //132 - or dword reg, mem : next byte is which register and the next 4 is the memory address
    //133 - or dword reg, reg : next byte is which register and the next is the other register

    //134 - or qword reg, const : next byte is which register and the next 8 is the constant value
    //135 - or qword reg, mem : next byte is which register and the next 4 is the memory address
    //136 - or qword reg, reg : next byte is which register and the next is the other register


    //137 - and byte reg, const : next byte is which register and the next is the constant value
    //138 - and byte reg, mem : next byte is which register and the next 4 is the memory address
    //139 - and byte reg, reg : next byte is which register and the next is the other register

    //140 - and word reg, const : next byte is which register and the next 2 is the constant value
    //141 - and word reg, mem : next byte is which register and the next 4 is the memory address
    //142 - and word reg, reg : next byte is which register and the next is the other register

    //143 - and dword reg, const : next byte is which register and the next 4 is the constant value
    //144 - and dword reg, mem : next byte is which register and the next 4 is the memory address
    //145 - and dword reg, reg : next byte is which register and the next is the other register

    //146 - and qword reg, const : next byte is which register and the next 8 is the constant value
    //147 - and qword reg, mem : next byte is which register and the next 4 is the memory address
    //148 - and qword reg, reg : next byte is which register and the next is the other register

    //149 - xor byte reg, const : next byte is which register and the next is the constant value
    //150 - xor byte reg, mem : next byte is which register and the next 4 is the memory address
    //151 - xor byte reg, reg : next byte is which register and the next is the other register

    //152 - xor word reg, const : next byte is which register and the next 2 is the constant value
    //153 - xor word reg, mem : next byte is which register and the next 4 is the memory address
    //154 - xor word reg, reg : next byte is which register and the next is the other register

    //155 - xor dword reg, const : next byte is which register and the next 4 is the constant value
    //156 - xor dword reg, mem : next byte is which register and the next 4 is the memory address
    //157 - xor dword reg, reg : next byte is which register and the next is the other register

    //158 - xor qword reg, const : next byte is which register and the next 8 is the constant value
    //159 - xor qword reg, mem : next byte is which register and the next 4 is the memory address
    //160 - xor qword reg, reg : next byte is which register and the next is the other register

    //161 - shl byte reg, const : next byte is which register and the next is the constant value
    //162 - shl byte reg, mem : next byte is which register and the next 4 is the memory address
    //163 - shl byte reg, reg : next byte is which register and the next is the other register

    //164 - shl word reg, const : next byte is which register and the next 2 is the constant value
    //165 - shl word reg, mem : next byte is which register and the next 4 is the memory address
    //166 - shl word reg, reg : next byte is which register and the next is the other register

    //167 - shl dword reg, const : next byte is which register and the next 4 is the constant value
    //168 - shl dword reg, mem : next byte is which register and the next 4 is the memory address
    //169 - shl dword reg, reg : next byte is which register and the next is the other register

    //170 - shl qword reg, const : next byte is which register and the next 8 is the constant value
    //171 - shl qword reg, mem : next byte is which register and the next 4 is the memory address
    //172 - shl qword reg, reg : next byte is which register and the next is the other register

    //173 - shr byte reg, const : next byte is which register and the next is the constant value
    //174 - shr byte reg, mem : next byte is which register and the next 4 is the memory address
    //175 - shr byte reg, reg : next byte is which register and the next is the other register

    //176 - shr word reg, const : next byte is which register and the next 2 is the constant value
    //177 - shr word reg, mem : next byte is which register and the next 4 is the memory address
    //178 - shr word reg, reg : next byte is which register and the next is the other register

    //179 - shr dword reg, const : next byte is which register and the next 4 is the constant value
    //180 - shr dword reg, mem : next byte is which register and the next 4 is the memory address
    //181 - shr dword reg, reg : next byte is which register and the next is the other register

    //182 - shr qword reg, const : next byte is which register and the next 8 is the constant value
    //183 - shr qword reg, mem : next byte is which register and the next 4 is the memory address
    //184 - shr qword reg, reg : next byte is which register and the next is the other register
    //--------------------------------------------

    //STACK OPERATIONS
    //--------------------------------------------
    //185 - push byte reg : next byte is which register
    //186 - push byte mem : next 4 bytes is the memory address
    //187 - push byte const : next byte is the constant

    //188 - push word reg : next byte is which register
    //189 - push word mem : next 4 bytes is the memory address
    //190 - push word const : next 2 bytes is the constant

    //191 - push dword reg : next byte is which register
    //192 - push dword mem : next 4 bytes is the memory address
    //193 - push dword const : next 4 bytes is the constant

    //194 - push qword reg : next byte is which register
    //195 - push qword mem : next 4 bytes is the memory address
    //196 - push qword const : next 8 bytes is the constant


    //197 - pop byte reg : next byte is which register
    //198 - pop byte mem : next 4 bytes is the memory address

    //199 - pop word reg : next byte is which register
    //200 - pop word mem : next 4 bytes is the memory address

    //201 - pop dword reg : next byte is which register
    //202 - pop dword mem : next 4 bytes is the memory address

    //203 - pop qword reg : next byte is which register
    //204 - pop qword mem : next 4 bytes is the memory address

    //205 - proc label : next 4 bytes is the code line of the function
    //206 - ret
    //207 - call label : next 4 bytes is the code line to jump to
    //--------------------------------------------

    //DATA OPERATIONS
    //--------------------------------------------

    //207 - byte label const: next byte is the value defualt is 0
    //208 - word label const: next 2 byte is the value defualt is 0
    //209 - dword label const: next 4 byte is the value defualt is 0
    //210 - qword label const: next 8 byte is the value defualt is 0
    //211 - float label const: next 4 byte is the value defualt is 0
    //212 - double label const: next 8 byte is the value defualt is 0

    //213 - byte array label const: next 4 bytes is the amount
    //214 - word array label const: next 4 bytes is the amount
    //215 - dword array label const: next 4 bytes is the amount
    //216 - qword array label const: next 4 bytes is the amount
    //217 - float array label const: next 4 bytes is the amount
    //218 - double array label const: next 4 bytes is the amount

    //--------------------------------------------


    //MEMORY OPERATIONS
    //--------------------------------------------
    //219 - malloc reg, const : next 4 bytes is the amount to malloc
    //220 - malloc reg, reg : next byte is the register
    //221 - malloc reg, mem : next 4 bytes is memory address

    //222 - free reg, const : next byte is the register and the next 4 bytes is the amount 
    //223 - free reg, reg : next byte is the register and the byte is the other register
    //224 - free reg, mem : next byte is the register and the 4 bytes is the memory address

    //225 - copy mem, mem : the 4 bytes is the memory address and the next 4 bytes is the other memory address
    //226 - copy mem, reg : the 4 bytes is the memory address and the next byte is the other register
    //227 - copy reg, reg : the byte is the register and the next byte is the other register
    //228 - copy reg, mem : the byte is the register and the next next 4 bytes is the other memory address
    //--------------------------------------------


    //INTERUPTS OPERATIONS
    //--------------------------------------------

    //229 - int const : next byte is the const
    //230 - int reg : next byte is the register
    //231 - int mem : next 4 byte is the memory address

    //--------------------------------------------

    //STRUCT OPERATIONS
    //--------------------------------------------
    //232 - struct label : next byte is the length of the label string
    //233 - field byte label : next byte is the length of the label string
    //234 - field word label :  next byte is the length of the label string
    //235 - field dword label : next byte is the length of the label string
    //236 - field qword label : next byte is the length of the label string
    //237 - field float label : next byte is the length of the label string
    //238 - field double label : next byte is the length of the label string
    //239 - field label label : next byte is the length of the label string
    //240 - end struct

    //241 - inst label, label : next byte is the length of the label string
    //242 - del label

    //243 - mov label, label, const
    //244 - mov label, label, reg
    //245 - mov label, label, mem
    //246 - mov reg, label, label
    //247 - mov mem, label, label

    //248 - size reg, label
    //249 - size mem, label
    //--------------------------------------------

    //250 - mod byte reg, const
    //251 - mod byte reg, reg
    //252 - mod byte reg, mem
    //251 - mod word reg, reg
    //252 - mod dword reg, reg
    //253 - mod qword reg, reg

    //255 - nop

    public unsafe class Commands
    {
        /// <summary>
        /// The amount of the commands.
        /// </summary>
        private const int COMMANDS = 255;

        public delegate bool MakeCommand(BinaryReader reader);

        public TaskState State;
        public MakeCommand[] MakeCommands = new MakeCommand[COMMANDS];
        public string LastMsg;
        public Commands(TaskState state) 
        {
            this.State = state;
            //nop
            MakeCommands[0] = (r) => { LastMsg = "s"; return true; };

            //mov
            new CommandsImp.Mov(this);
        }
    }
}
