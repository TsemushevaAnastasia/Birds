using System;
using System.Collections.Generic;
using System.Text;

namespace Birds
{
    interface IFlying
    {
        double f_speed { get; set; }
        double f_heigt { get; set; }
    }

    interface ISwimming
    {
        double s_speed { get; set; }
        double s_deep { get; set; }
    }

    enum Gender
    {
        male,
        female
    }
    class Birds
    {
        protected string _name;
        protected Gender _gen;

        protected Birds _mother;
        protected Birds _father;

        private void Erase()
        {
            _name = null;
        }
        private void Clone(Birds other)
        {
            string a_name;
            a_name = other._name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null)
                    throw new Exception("Name is NULL!");
                if (value[0] == '\0')
                    throw new Exception("Name is empty!");
                Erase();
                _name = value;
            }
        }
        public string GetGender()
        {
            if (_gen == Gender.male)
                return "male";
            else
                return "female";
        }

        public Birds(string a_name, Gender s, Birds mth, Birds fth) 
        {
            this.Name = a_name;

            _gen = s;

            if (mth != null && mth._gen == Gender.male)
                throw new Exception ("Mother's gender must be female!");
            if (fth != null && fth._gen == Gender.female)
                throw new Exception ("Father's gender must be male!");

            _mother = mth;

            _father = fth;
        }

        public Birds(string a_name, Gender s) 
        {
            this.Name = a_name;
            _gen = s;
        }

        public Birds(string a_name)
        {
            this.Name = a_name;
        }

        public Birds(Birds other)
        {
            Clone(other);
        }

        public Birds(): this("Bird") { }
        

        ~Birds()
        { 

        }

    }

    class Сhicken : Birds
    {
        public Сhicken LayEgg(Сhicken fth, string _name, Gender s)
        {
            if (_gen == Gender.male)
                throw new Exception("Mother can't be male.");

            string b = "Nestling";
            if (_name != null)
                b = _name;
            Сhicken child = new Сhicken(b, s, this, fth);
            return child;
        }
        public void PrintInfo()
        {
            if (_gen == Gender.female)
                Console.WriteLine("Курица {0}:", _name);
            else
                Console.WriteLine("Петух {0}:", _name);
            if (_mother != null && _father != null)
                Console.WriteLine("Родители - {0} и {1}", _mother.Name, _father.Name);
            else
                Console.WriteLine("Родители неизвестны");
            Console.WriteLine();
        }
        public Сhicken(string a_name, Gender s, Birds mth, Birds fth) : base(a_name, s, mth, fth)
        {
        }
        public Сhicken(string a_name, Gender s) : base(a_name, s)
        {
        }
        public Сhicken(string a_name) : base(a_name)
        {
        }
        public Сhicken(): this("Сhicken") { }

    }

    class Duck : Birds, IFlying, ISwimming
    {
        public double f_speed { get; set; }

        public double f_heigt { get; set; }
        public double s_speed { get; set; }

        public double s_deep { get; set; }

        public Duck(string a_name) : base(a_name)
        {
            f_speed = 0;
            f_heigt = 0;
            s_speed = 0;
            s_deep = 0;
        }

        public Duck(string a_name, double a_f_speed, double a_f_heiht, double a_s_speed, double a_s_deep) : base(a_name)
        {
            f_speed = a_f_speed;
            f_heigt = a_f_heiht;
            s_speed = a_s_speed;
            s_deep = a_s_deep;
        }
        public Duck(string a_name, Gender s) : base(a_name, s)
        {
            f_speed = 0;
            f_heigt = 0;
            s_speed = 0;
            s_deep = 0;
        }

        public Duck(string a_name, Gender s, double a_f_speed, double a_f_heiht, double a_s_speed, double a_s_deep) : base(a_name, s)
        {
            f_speed = a_f_speed;
            f_heigt = a_f_heiht;
            s_speed = a_s_speed;
            s_deep = a_s_deep;
        }

        public Duck(string a_name, Gender s, Birds mth, Birds fth, double a_f_speed, double a_f_heiht, double a_s_speed, double a_s_deep) : base (a_name, s, mth, fth)
        {
            f_speed = a_f_speed;
            f_heigt = a_f_heiht;
            s_speed = a_s_speed;
            s_deep = a_s_deep;
        }
        public Duck(string a_name, Gender s, Birds mth, Birds fth) : base(a_name, s, mth, fth)
        {
            f_speed = 0;
            f_heigt = 0;
            s_speed = 0;
            s_deep = 0;
        }

        public Duck() : this("Duck") { }

        public Duck LayEgg(Duck fth, string _name, Gender s)
        {
            if (_gen == Gender.male)
                throw new Exception("Mother can't be male.");

            string b = "Nestling";
            if (_name != null)
                b = _name;
            Duck child = new Duck(b, s, this, fth);
            return child;
        }
        public void PrintInfo()
        {
            if (_gen == Gender.female)
                Console.WriteLine ("Утка {0}:", _name);
            else
                Console.WriteLine("Селезень {0}:", _name);
            if (f_speed == 0)
                Console.WriteLine("Скорость полета: неизвестно");
            else
                Console.WriteLine("Скорость полета: {0}", f_speed);
            if (s_speed == 0)
                Console.WriteLine("Скорость плавания: неизвестно");
            else
                Console.WriteLine("Скорость плавания: {0}", s_speed);
            if (f_heigt == 0)
                Console.WriteLine("Высота полета: неизвестно");
            else
                Console.WriteLine("Высота полета: {0}", f_heigt);
            if (s_deep == 0)
                Console.WriteLine("Глубина ныряния: неизвестно");
            else
                Console.WriteLine("Глубина ныряния: {0}", s_deep);
            if (_mother != null && _father != null)
                Console.WriteLine("Родители - {0} и {1}", _mother.Name, _father.Name);
            else
                Console.WriteLine("Родители неизвестны");
            Console.WriteLine();
        }
    }

    class Eagle : Birds, IFlying
    {
        public double f_speed { get; set; }

        public double f_heigt { get; set; }

        public Eagle(string a_name) : base(a_name)
        {
            f_speed = 0;
            f_heigt = 0;
        }

        public Eagle(string a_name, double a_f_speed, double a_f_heiht) : base(a_name)
        {
            f_speed = a_f_speed;
            f_heigt = a_f_heiht;
        }
        public Eagle(string a_name, Gender s) : base(a_name, s)
        {
            f_speed = 0;
            f_heigt = 0;
        }

        public Eagle(string a_name, Gender s, double a_f_speed, double a_f_heiht) : base(a_name, s)
        {
            f_speed = a_f_speed;
            f_heigt = a_f_heiht;
        }

        public Eagle(string a_name, Gender s, Birds mth, Birds fth, double a_f_speed, double a_f_heiht) : base(a_name, s, mth, fth)
        {
            f_speed = a_f_speed;
            f_heigt = a_f_heiht;
        }
        public Eagle(string a_name, Gender s, Birds mth, Birds fth) : base(a_name, s, mth, fth)
        {
            f_speed = 0;
            f_heigt = 0;
        }

        public Eagle() : this("Eagle") { }

        public Eagle LayEgg(Eagle fth, string _name, Gender s)
        {
            if (_gen == Gender.male)
                throw new Exception("Mother can't be male.");

            string b = "Nestling";
            if (_name != null)
                b = _name;
            Eagle child = new Eagle(b, s, this, fth);
            return child;
        }
        public void PrintInfo()
        {
            if (_gen == Gender.female)
                Console.WriteLine("Орлиха {0}:", _name);
            else
                Console.WriteLine("Орел {0}:", _name);
            if (f_speed == 0)
                Console.WriteLine("Скорость полета: неизвестно");
            else
                Console.WriteLine("Скорость полета: {0}", f_speed);
            if (f_heigt == 0)
                Console.WriteLine("Высота полета: неизвестно");
            else
                Console.WriteLine("Высота полета: {0}", f_heigt);
            if (_mother != null && _father != null)
                Console.WriteLine("Родители - {0} и {1}", _mother.Name, _father.Name);
            else
                Console.WriteLine("Родители неизвестны");
            Console.WriteLine();
        }
    }

    class Pinguin: Birds, ISwimming
    {
        public double s_speed { get; set; }

        public double s_deep { get; set; }

        public Pinguin(string a_name) : base(a_name)
        {
            s_speed = 0;
            s_deep = 0;
        }

        public Pinguin(string a_name, double a_s_speed, double a_s_deep) : base(a_name)
        {
            s_speed = a_s_speed;
            s_deep = a_s_deep;
        }
        public Pinguin(string a_name, Gender s) : base(a_name, s)
        {
            s_speed = 0;
            s_deep = 0;
        }

        public Pinguin(string a_name, Gender s, double a_s_speed, double a_s_deep) : base(a_name, s)
        {
            s_speed = a_s_speed;
            s_deep = a_s_deep;
        }

        public Pinguin(string a_name, Gender s, Birds mth, Birds fth, double a_s_speed, double a_s_deep) : base(a_name, s, mth, fth)
        {
            s_speed = a_s_speed;
            s_deep = a_s_deep;
        }
        public Pinguin(string a_name, Gender s, Birds mth, Birds fth) : base(a_name, s, mth, fth)
        {
            s_speed = 0;
            s_deep = 0;
        }

        public Pinguin() : this("Pinguin") { }

        public Pinguin LayEgg(Pinguin fth, string _name, Gender s)
        {
            if (_gen == Gender.male)
                throw new Exception("Mother can't be male.");

            string b = "Nestling";
            if (_name != null)
                b = _name;
            Pinguin child = new Pinguin(b, s, this, fth);
            return child;
        }
        public void PrintInfo()
        {
            if (_gen == Gender.female)
                Console.WriteLine("Пингвиниха {0}:", _name);
            else
                Console.WriteLine("Пингвин {0}:", _name);
            if (s_speed == 0)
                Console.WriteLine("Скорость плавания: неизвестно");
            else
                Console.WriteLine("Скорость плавания: {0}", s_speed);
            if (s_deep == 0)
                Console.WriteLine("Глубина ныряния: неизвестно");
            else
                Console.WriteLine("Глубина ныряния: {0}", s_deep);
            if (_mother != null && _father != null)
                Console.WriteLine("Родители - {0} и {1}", _mother.Name, _father.Name);
            else
                Console.WriteLine("Родители неизвестны");
            Console.WriteLine();
        }
    }
}
