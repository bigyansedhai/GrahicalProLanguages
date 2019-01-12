using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GraphicalProLanguages
{
    public partial class Form1 : Form, Shape
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Delcear veriable passing 0 value
        /// </summary>
        Pen myPen = new Pen(System.Drawing.Color.Black);
        SolidBrush brush = new SolidBrush(Color.Red);
        int x = 0, y = 0, toX = 0, toY = 0, radius = 0, width = 0, height = 0, repeatval = 0, counter = 0;
        int loop = 0, kStart = 0, ifcounter = 0;
        bool loopcheck = false;

        

        /// <summary>
        /// save Dialog Create for save txt which is written inside textbox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)

        { 
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(save.FileName));
                write.WriteLine(textBox1.Text);
                write.Close();
                MessageBox.Show("File Saved Successfully");


            }
         
           
        }
        /// <summary>
        /// open Browse .txt file from computer
        /// create file location
        /// displays the text inside the file on TextBox named as textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse file from specified folder";
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
            ofd.Filter = "DOCX files(*.docx)|*.docx|All files(*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            ofd.FilterIndex = 0;
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //// Insert code to read the stream here
                        }
                    }
                }
                catch (Exception ex)
                {


                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                    textBox1.Text = File.ReadAllText(ofd.FileName);            
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void draw(Graphics g)
        {
            g.DrawLine(myPen, x, y, toX, toY);





        }

        public void set(params int[] list)
        {
            this.x = list[0];
            this.y = list[1];
            this.toX = list[2];
            this.toY = list[3];
        }

        /// <summary>
        ///  Draw Click Event
        ///  To excute read function and Draw graphics inside the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)

        {
            Graphics g = panel1.CreateGraphics();
            string command = textBox1.Text;
            read(g, command);




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {




        }
        public int getX()
        {
            return x;
        }


        public int getY()
        {
            return y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="integer parameter passing of move to method"></param>
        /// <param name=" toX,toY"></param>
        public void moveTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }

        /// <summary>
        /// integer parameter passing of draw to method
        /// </summary>
        /// <param name="">x,y</param>
        /// <param name=" toX,toY"></param>
        public void drawto(int toX, int toY)
        {
            x = toX;
            y = toY;


        }
        public void drawLine(int toX, int toY)
        {

            Graphics g = panel1.CreateGraphics();

            g.DrawLine(myPen, x, y, toX, toY);
            moveTo(toX, toY);


        }
       
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                Graphics g = panel1.CreateGraphics();
                string command = textBox1.Text;
                read(g, command);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// create read function passing param Graphics,string
        /// using try catch
        /// using if else condition
        /// if condition will fail ,the line throw error Exception
        /// </summary>
        /// <param name=""></param>
        /// <param name=" g,command"></param>
        public void read(Graphics g, string command)
        {
            try
            {
                command = command.ToLower();
                String[] commandline = command.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < commandline.Length; k++)
                {
                    string[] commands = commandline[k].Split(' ');
                    if (commands[0].Equals("moveto"))
                    {
                        panel1.Refresh();
                        string[] cordinate = commands[1].Split(',');
                        if (cordinate.Length != 2)
                        {
                            MessageBox.Show("Incorrect Parameter");
                        }
                        else
                        {

                            int x = 0, y = 0;
                            Int32.TryParse(cordinate[0], out x);
                            Int32.TryParse(cordinate[1], out y);

                            moveTo(x, y);


                            Console.WriteLine(x + "," + y);
                        }
                    }
                    else
                    if (commands[0].Equals("drawto"))
                    {

                        int x, y;
                        string[] list = commands[1].Split(',');
                        if (list.Length != 2)
                        {
                            MessageBox.Show("Invalid Parameter");
                        }
                        else
                        {
                            Int32.TryParse(list[0], out x);
                            Int32.TryParse(list[1], out y);
                            drawto(x, y);
                            draw(g);
                        }
                    }
                    else
                    if (commands[0].Equals("drawline"))
                    {
                        int x, y;
                        string[] list = commands[1].Split(',');
                        if (list.Length != 2)
                        {
                            MessageBox.Show("Incorrect Parameter");
                        }
                        else
                        {
                           Int32.TryParse(list[0], out x);
                            Int32.TryParse(list[1], out y);
                            drawLine(x, y);
                        }
                    }
                    else
                    if (commands[0].Equals("rectangle"))
                    {
                        ShapeFactory shapeFactory = new ShapeFactory();
                        Shape Rectangle = shapeFactory.getShape("Rectangle");
                        Rectangle rc = new Rectangle();
                        rc.set(x, y, width, height);
                        rc.draw(g);

                        /// <summary>
                        /// initial draw rectangle fillColor from brush instance
                        /// </summary>
                        g.FillRectangle(brush, x, y, width, height);
                        string[] dimensions = commands[1].Split(',');
                        if (!dimensions[0].Equals("width"))
                        {
                            Int32.TryParse(dimensions[0], out width);
                        }
                        if (!dimensions[1].Equals("height"))
                        {
                            Int32.TryParse(dimensions[1], out height);
                        }

                    }
                    else
                    if (commands[0].Equals("circle"))
                    {

                        if (!commands[1].Equals("radius"))
                        {
                            Int32.TryParse(commands[1], out radius);
                            ShapeFactory shapeFactory = new ShapeFactory();
                            Circle c = new Circle();

                            Shape circle = shapeFactory.getShape("circle");

                            c.set(x, y, radius);
                            c.draw(g);
                            g.FillEllipse(brush, x, y, radius, radius);
                        }

                    }

                    else
                    if (commands[0].Equals("triangle"))
                    {
                        ShapeFactory shapeFactory = new ShapeFactory();
                        Shape Rectangle = shapeFactory.getShape("triangle");
                        Triangle tr = new Triangle();
                        tr.set(x, y, width, height, height);
                        tr.draw(g);

                        /// <summary>
                        /// initial draw triangle fillColor from brush instance before repeat triangle doesn't fill by Color
                        /// </summary>
                        Point[] p = new Point[3];
                        p[0].X = x;
                        p[0].Y = y;

                        p[1].X = x + width;
                        p[1].Y = y;

                        p[2].X = x + width;
                        p[2].Y = y - height;

                        g.FillPolygon(brush, p);


                  
                        string[] dimensions = commands[1].Split(',');
                        if (!dimensions[0].Equals("width"))
                        {
                            Int32.TryParse(dimensions[0], out width);
                        }
                        if (!dimensions[1].Equals("height"))
                        {
                            Int32.TryParse(dimensions[1], out height);
                        }


                    }
                    else
                     if (commands[0].Equals("polygon"))
                    {


                        ShapeFactory shapeFactory = new ShapeFactory();
                        Shape Polygon = shapeFactory.getShape("polygon");
                        Polygon pl = new Polygon(g, width, height);

                        pl.set(x, y, width, height);
                        pl.draw(g);


                        /// <summary>
                        /// initial draw polygon fillColor from brush instance before repeat polygon doesn't fill by Color
                        /// </summary>
                        Point point1 = new Point(x, y - (height / 2));
                        Point point2 = new Point(x - (width / 2), y + (height / 2));
                        Point point3 = new Point(x + (width / 2), y + (height / 2));
                        Point point4 = new Point(x + width, y - height);
                        Point point5 = new Point(x - width, y - height);

                        Point[] curvePoints = { point1,point2, point3,point4,point5};
                        g.FillPolygon(brush, curvePoints);

                        string[] dimensions = commands[1].Split(',');
                        if (!dimensions[0].Equals("width"))
                        {
                            Int32.TryParse(dimensions[0], out width);
                        }
                        if (!dimensions[1].Equals("height"))
                        {
                            Int32.TryParse(dimensions[1], out height);
                        }

                    }
                    else if (commands[0].Equals("repeat") == true)
                    {
                        Int32.TryParse(commands[1], out repeatval);

                        if (commands[2].Equals("circle") == true)
                        {
                            int r;
                            Int32.TryParse(commands[4], out r);
                            if (commands[3].Equals("+") == true)
                            {

                                for (int rc = 0; rc < repeatval; rc++)
                                {
                                    radius = radius + r;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Circle c = new Circle();

                                    Shape circle = shapeFactory.getShape("circle");

                                    c.set(x, y, radius);
                                    c.draw(g);
                                }
                            }
                            else if (commands[3].Equals("-") == true)
                            {
                                for (int rc = 0; rc < repeatval; rc++)
                                {
                                    radius = radius + r;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Circle c = new Circle();

                                    Shape circle = shapeFactory.getShape("circle");

                                    c.set(x, y, radius);
                                    c.draw(g);
                                }

                            }
                        }
                        else if (commands[2].Equals("rectangle") == true)
                        {
                            int increment;
                            Int32.TryParse(commands[4], out increment);
                            if (commands[3].Equals("+") == true)
                            {

                                for (int rn = 0; rn < repeatval; rn++)
                                {
                                    width = width + increment;
                                    height = height + increment;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Shape Rectangle = shapeFactory.getShape("Rectangle");
                                    Rectangle rc = new Rectangle();
                                    rc.set(x, y, width, height);
                                    rc.draw(g);

                                }
                            }
                            else if (commands[3].Equals("-") == true)
                            {
                                for (int rn = 0; rn < repeatval; rn++)
                                {
                                    width = width - increment;
                                    height = height - increment;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Shape Rectangle = shapeFactory.getShape("Rectangle");
                                    Rectangle rc = new Rectangle();
                                    rc.set(x, y, width, height);
                                    rc.draw(g);


                                }

                            }
                        }
                        else if (commands[2].Equals("triangle") == true)
                        {
                            int increment;
                            Int32.TryParse(commands[4], out increment);
                            if (commands[3].Equals("+") == true)
                            {

                                for (int rc = 0; rc < repeatval; rc++)
                                {
                                    width = width + increment;
                                    height = height + increment;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Shape Rectangle = shapeFactory.getShape("triangle");
                                    Triangle tr = new Triangle();
                                    tr.set(x, y, width, height, height);
                                    tr.draw(g);

                                }
                            }
                            else if (commands[3].Equals("-") == true)
                            {
                                for (int rc = 0; rc < repeatval; rc++)
                                {
                                    width = width - increment;
                                    height = height - increment;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Shape Rectangle = shapeFactory.getShape("triangle");
                                    Triangle tr = new Triangle();
                                    tr.set(x, y, width, height, height);
                                    tr.draw(g);

                                }

                            }

                        }
                        else if (commands[2].Equals("polygon") == true)
                        {
                            int increment;
                            Int32.TryParse(commands[4], out increment);
                            if (commands[3].Equals("+") == true)
                            {

                                for (int rc = 0; rc < repeatval; rc++)
                                {
                                    width = width + increment;
                                    height = height + increment;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Shape Polygon = shapeFactory.getShape("polygon");
                                    Polygon pl = new Polygon(g, width, height);

                                    pl.set(x, y, width, height);
                                    pl.draw(g);


                                }
                            }
                            else if (commands[3].Equals("-") == true)
                            {
                                for (int rc = 0; rc < repeatval; rc++)
                                {
                                    width = width - increment;
                                    height = height - increment;
                                    ShapeFactory shapeFactory = new ShapeFactory();
                                    Shape Polygon = shapeFactory.getShape("polygon");
                                    Polygon pl = new Polygon(g, width, height);

                                    pl.set(x, y, width, height);
                                    pl.draw(g);


                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("Error Syntax found");
                        }
                    }
                    else if (commands[0].Equals("radius") == true)
                    {

                        int r;
                        if (commands[1].Equals("=") == true)
                        {
                            Int32.TryParse(commands[2], out radius);
                        }
                        else if (commands[1].Equals("+") == true)
                        {
                            Int32.TryParse(commands[2], out r);
                            radius = radius + r;
                        }
                        else if (commands[1].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                Int32.TryParse(commands[2], out r);
                                radius = radius - r;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Syntax Error");
                        }
                    }
                    else if (commands[0].Equals("width") == true)
                    {

                        int w;
                        if (commands[1].Equals("=") == true)
                        {
                            Int32.TryParse(commands[2], out width);
                        }
                        else if (commands[1].Equals("+") == true)
                        {
                            Int32.TryParse(commands[2], out w);
                            width = width + w;

                        }
                        else if (commands[1].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                Int32.TryParse(commands[2], out w);
                                width = width - w;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Syntax Error");
                        }
                    }
                    else if (commands[0].Equals("height") == true)
                    {

                        int h;
                        if (commands[1].Equals("=") == true)
                        {
                            Int32.TryParse(commands[2], out height);
                        }
                        else if (commands[1].Equals("+") == true)
                        {
                            Int32.TryParse(commands[2], out h);
                            height = height + h;

                        }
                        else if (commands[1].Equals("-") == true)
                        {
                            for (int rc = 0; rc < repeatval; rc++)
                            {
                                Int32.TryParse(commands[2], out h);
                                height = height - h;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Syntax Error");
                        }
                    }
                    else if (commands[0].Equals("loop") == true)
                    {
                        for (int j = k + 1; j < commandline.Length; j++)
                        {
                            string[] cmd1 = commandline[j].Split(' ');
                            for (int d = 0; d < counter; d++)
                            {
                                if (cmd1[0].Equals("radius") == true)
                                {
                                    int r;
                                    if (cmd1[1].Equals("+") == true)
                                    {
                                        Int32.TryParse(cmd1[2], out r);
                                        radius = radius + r;
                                        ShapeFactory shapeFactory = new ShapeFactory();
                                        Circle c = new Circle();

                                        Shape circle = shapeFactory.getShape("circle");

                                        c.set(x, y, radius);
                                        c.draw(g);
                                        g.FillEllipse(brush, x, y, radius, radius);
                                    }
                                    else if (cmd1[1].Equals("-") == true)
                                    {
                                        for (int rc = 0; rc < repeatval; rc++)
                                        {
                                            Int32.TryParse(cmd1[2], out r);
                                            radius = radius - r;
                                            ShapeFactory shapeFactory = new ShapeFactory();
                                            Circle c = new Circle();

                                            Shape circle = shapeFactory.getShape("circle");

                                            c.set(x, y, radius);
                                            c.draw(g);
                                            g.FillEllipse(brush, x, y, radius, radius);
                                        }

                                    }

                                }
                                else if (cmd1[0].Equals("width") == true)
                                {
                                    int w;
                                    if (cmd1[1].Equals("+") == true)
                                    {
                                        Int32.TryParse(cmd1[2], out w);
                                        width = width + w;
                                        ShapeFactory shapeFactory = new ShapeFactory();
                                        Shape Rectangle = shapeFactory.getShape("Rectangle");
                                        Rectangle rc = new Rectangle();
                                        rc.set(x, y, width, height);
                                        rc.draw(g);
                                        g.FillRectangle(brush, x, y, width, height);

                                    }
                                }
                                else if (cmd1[0].Equals("height") == true)
                                {
                                    int h;
                                    if (cmd1[1].Equals("+") == true)
                                    {
                                        Int32.TryParse(cmd1[2], out h);
                                        height = height + h;
                                        ShapeFactory shapeFactory = new ShapeFactory();
                                        Shape Rectangle = shapeFactory.getShape("Rectangle");
                                        Rectangle rc = new Rectangle();
                                        rc.set(x, y, width, height);
                                        rc.draw(g);
                                        g.FillRectangle(brush, x, y, width, height);

                                    }
                                }

                            }

                        }

                    }
                    else if (commands[0].Equals("if"))
                    {

                        if (ifcounter == (loop + 1))
                        {
                            if (commands[0].Equals("radius"))
                            {
                                if (commands[1].Equals("="))
                                {
                                    Int32.TryParse(commands[2], out radius);
                                    Console.WriteLine(radius);
                                }
                                else
                                if (commands[1].Equals("+"))
                                {
                                    int r;
                                    Int32.TryParse(commands[2], out r);
                                    radius = radius + r;
                                    Console.WriteLine(radius);
                                }
                                else
                                if (commands[1].Equals("-"))
                                {
                                    int r;
                                    Int32.TryParse(commands[2], out r);
                                    radius = radius - r;
                                }

                            }
                            else if (commands[0].Equals("width"))
                            {
                                if (commands[1].Equals("="))
                                {
                                    Int32.TryParse(commands[2], out width);
                                    Console.WriteLine(width);
                                }
                                else
                                if (commands[1].Equals("+"))
                                {
                                    int w;
                                    Int32.TryParse(commands[2], out w);
                                    width = width + w;
                                }
                                else
                                if (commands[1].Equals("-"))
                                {
                                    int w;
                                    Int32.TryParse(commands[2], out w);
                                    width = width - w;
                                }
                            }
                            else if (commands[0].Equals("height"))
                            {
                                if (commands[1].Equals("="))
                                {
                                    Int32.TryParse(commands[2], out height);
                                    Console.WriteLine(height);
                                }
                                else
                                if (commands[1].Equals("+"))
                                {
                                    int h;
                                    Int32.TryParse(commands[2], out h);
                                    height = height + h;
                                }
                                else
                                if (commands[1].Equals("-"))
                                {
                                    int h;
                                    Int32.TryParse(commands[2], out h);
                                    height = height - h;
                                }
                            }
                        }


                    }
                    else
                    if (commands[0].Equals("endif"))
                    {
                        if (commands[1].Equals("radius"))
                        {

                            if (commands[2].Equals("="))
                            {

                                int endifvar;
                                Int32.TryParse(commands[3], out endifvar);
                                if (radius == endifvar)
                                {
                                    break;
                                }
                            }

                        }
                        else
                        if (commands[1].Equals("width"))
                        {
                            if (commands[2].Equals("="))
                            {
                                int endifvar;
                                Int32.TryParse(commands[3], out endifvar);
                                if (width == endifvar)
                                {
                                    break;
                                }
                            }

                        }
                        else
                        if (commands[1].Equals("height"))
                        {
                            if (commands[2].Equals("="))
                            {
                                int endifvar;
                                Int32.TryParse(commands[3], out endifvar);
                                if (height == endifvar)
                                {
                                    break;
                                }
                            }

                        }

                    }
                    else if (commands[0].Equals("endloop") == true)
                    {

                    }
                    else if (loopcheck == true)
                    {
                        MessageBox.Show("invalid Loop Command");
                    }
                    else if (!command[1].Equals(null))
                    {
                        
                        int errorLine = k + 1;
                        MessageBox.Show("Invalid command recognised on line " + errorLine, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

