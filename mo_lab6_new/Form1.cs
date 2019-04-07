using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mo_lab6_new
{
    public partial class Form1 : Form
    {
        Random r = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
        List<Specimen> s;
        double c1, c2, c3, c4, c5;
        double value, eps;
        int a, b;
        int count;

        //int flag = 0;

        void specs_test()
        {
            //double sum = 0;
            List<Specimen> s_test = new List<Specimen>();
            Specimen spec;
            //Random r = new Random(DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);

            c1 = Convert.ToDouble(textBox1.Text);
            c2 = Convert.ToDouble(textBox2.Text);
            c3 = Convert.ToDouble(textBox3.Text);
            c4 = Convert.ToDouble(textBox4.Text);
            c5 = Convert.ToDouble(textBox5.Text);
            count = Convert.ToInt32(textBox6.Text);

            for (int i = 0; i < count; i++)
            {
                spec = new Specimen(r.Next(-100, 100), r.Next(-100, 100));

                if(spec.x < 0)
                {
                    spec.x -= r.Next(-1, 10) / 100.00;
                }
                else
                {
                    spec.x += r.Next(-1, 10) / 100.00;
                }

                if (spec.y < 0)
                {
                    spec.y -= r.Next(-1, 10) / 100.00;
                }
                else
                {
                    spec.y += r.Next(-1, 10) / 100.00;
                }

                s_test.Add(spec);
            }

            console.Clear();
            chart1.Series[0].Points.Clear();

            for(int i = 0; i < count; i++)
            {
                console.AppendText(s_test[i].x + ", " + s_test[i].y + "\n");
                chart1.Series[0].Points.AddXY(s_test[i].x, s_test[i].y);

                s_test[i].fit = func(s_test[i].x, s_test[i].y);
                //sum += s_test[i].fit;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //specs_test();
        }

        double func(double x, double y)
        {
            return (c1 * x * x) + (c2 * x) + (c3 * x * y) + (c4 * y) + (c5 * y * y);
        }

        void drawResults_old()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            double min = s[0].fit, max = s[0].fit, inter1, inter2;

            for (int i = 0; i < count; i++)
            {
                if (s[i].fit <= min) //Поиск минимума
                {
                    min = s[i].fit;
                }

                if (s[i].fit >= max) //Поиск максимума
                {
                    max = s[i].fit;
                }
            }

            //inter1 = min + (((Math.Abs(min) + Math.Abs(max)) / 10.000)); // Наименьшие 10% значений функции - лучшие
            //inter2 = max - (((Math.Abs(min) + Math.Abs(max)) / 10.000) * 5); //Наибольшие 50% значений функции - худшие
            if (Math.Abs(min) > Math.Abs(max))
            {
                inter1 = 0.1 * Math.Abs(min);
                inter2 = 0.5 * Math.Abs(min);
            }
            else
            {
                inter1 = 0.1 * Math.Abs(max);
                inter2 = 0.5 * Math.Abs(max);
            }

            for (int i = 0; i < count; i++)
            {
                if (Math.Abs(s[i].fit) < inter1) //Лучшее решение
                {
                    chart1.Series[0].Points.AddXY(s[i].x, s[i].y);
                }
                else if (Math.Abs(s[i].fit) < inter2) //Обычное решение
                {
                    chart1.Series[1].Points.AddXY(s[i].x, s[i].y);
                }
                else //Наихудшее решение
                {
                    chart1.Series[2].Points.AddXY(s[i].x, s[i].y);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        void drawResults()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();

            double min = s[0].fit, max = s[0].fit, inter1, inter2;

            for (int i = 0; i < count; i++)
            {
                if (s[i].fit <= min) //Поиск минимума
                {
                    min = s[i].fit;
                }

                if (s[i].fit >= max) //Поиск максимума
                {
                    max = s[i].fit;
                }
            }

            //inter1 = min + (((Math.Abs(min) + Math.Abs(max)) / 10.000)); // Наименьшие 10% значений функции - лучшие
            //inter2 = max - (((Math.Abs(min) + Math.Abs(max)) / 10.000) * 5); //Наибольшие 50% значений функции - худшие
            if (Math.Abs(min) > Math.Abs(max))
            {
                inter1 = 0.1 * Math.Abs(min);
                inter2 = 0.5 * Math.Abs(min);
            }
            else
            {
                inter1 = 0.1 * Math.Abs(max);
                inter2 = 0.5 * Math.Abs(max);
            }

            for (int i = 0; i < count; i++)
            {
                if (Math.Abs(s[i].fit) < inter1) //Лучшее решение
                {
                    chart1.Series[0].Points.AddXY(s[i].x, s[i].y);
                    //console.AppendText(s[i].x + ", " + s[i].y + ", " + func(s[i].x, s[i].y) + "\n");
                }
                else if (Math.Abs(s[i].fit) < inter2) //Обычное решение
                {
                    chart1.Series[1].Points.AddXY(s[i].x, s[i].y);
                }
                else //Наихудшее решение
                {
                    chart1.Series[2].Points.AddXY(s[i].x, s[i].y);
                }
            }
        }

        void setFits() //Вычисление функции приспособленности
        {
            double minFunc = Double.MaxValue;

            for (int i = 0; i < count; i++)
            {
                double currentMinFunc = func(s[i].x, s[i].y);
                if (currentMinFunc <= minFunc)
                {
                    minFunc = currentMinFunc;
                }
            }

            for(int i = 0; i < count; i++)
            {
                s[i].fit = Math.Abs(minFunc - func(s[i].x, s[i].y));
            }

        }

        double sMin() //Поиск наименьшего значения fit (наилучшая приспособленность)
        {
            double min = s[0].fit;
            for(int i = 0; i < s.Count; i++)
            {
                if(s[i].fit <= min)
                {
                    min = s[i].fit;
                }
            }

            return min;
        }

        double sMax()
        {
            double max = s[0].fit;

            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].fit >= max)
                {
                    max = s[i].fit;
                }
            }

            return max;
        }

        void crossover(int s1, int s2)
        {
            double k = r.Next(0, 11);
            if(k < 5) //Обмен значениями x
            {
                k = s[s2].x;
                s[s2].x = s[s1].x;
                s[s1].x = k;
            }
            else //Обмен значениями y
            {
                k = s[s2].y;
                s[s2].y = s[s1].y;
                s[s1].y = k;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //specs_test();
            Specimen spec;
            bool f1, found = false; //Было ли найдено значение
            int result_id = -1; //Номер найденой лучшей точки

            int k = 0, crossovers = 0, mutations = 0; //Число итераций, скрещиваний, мутаций
            int s1 = -1;
            double avgFit;
            double l;
            double step;
            double temp;

            c1 = Convert.ToDouble(textBox1.Text);
            c2 = Convert.ToDouble(textBox2.Text);
            c3 = Convert.ToDouble(textBox3.Text);
            c4 = Convert.ToDouble(textBox4.Text);
            c5 = Convert.ToDouble(textBox5.Text);
            count = Convert.ToInt32(textBox6.Text);
            a = Convert.ToInt32(textBox7.Text);
            b = Convert.ToInt32(textBox8.Text);
            step = Math.Abs(b - a) / 100;

            value = Convert.ToDouble(textBox9.Text);
            eps = Convert.ToDouble(textBox10.Text);

            s = new List<Specimen>(); //Генерация особей в соответствии с количеством и диапазоном поиска
            for (int i = 0; i < count; i++)
            {
                spec = new Specimen(r.Next(a, b), r.Next(a, b));

                if (spec.x < 0)
                {
                    spec.x -= r.Next(-1, 10) / 100.00;
                }
                else
                {
                    spec.x += r.Next(-1, 10) / 100.00;
                }

                if (spec.y < 0)
                {
                    spec.y -= r.Next(-1, 10) / 100.00;
                }
                else
                {
                    spec.y += r.Next(-1, 10) / 100.00;
                }

                s.Add(spec);
            }

            //setFits();
            //drawResults();

            double prevBest = sMax();

            while(k != 1000 && !found)
            {
                k++;

                setFits();

                double max_s = sMax();
                double min_s = sMin();

                avgFit = (sMax() - sMin()) / 2.00;
                f1 = false;

                //int test = 0;

                for(int i = 0; i < s.Count; i++) //Скрещивание лучших особей
                {
                    if(s[i].fit <= avgFit) //Нашли особь для скрещивания
                    {
                        if(f1 == false) //Находим первую особь
                        {
                            f1 = true;
                            s1 = i;
                        }
                        else //Находим вторую особь
                        {
                            crossover(s1, i);
                            f1 = false;
                            crossovers++;
                            //test++;
                        }
                    }
                }
                /////////// Конец скрещиваний

                for (int i = 0; i < s.Count; i++) //Мутации всех особей
                {
                    mutations++;
                    if(s[i].fit <= avgFit) //Слабая мутация
                    {
                        l = r.Next(0, 11);

                       if(l < 5) //Мутация по x
                        {
                            temp = s[i].x + (step * r.Next(0, 10) / 10);
                            if (temp >= a && temp <= b)
                            {
                                s[i].x = temp;
                            }
                            else if (temp > a)
                            {
                                s[i].x = a;
                            }
                            else if (temp < b)
                            {
                                s[i].x = b;
                            }
                            else
                            {
                                s[i].x = s[i].x - (step * r.Next(0, 10) / 10);
                            }
                        }
                       else // Мутация по y
                        {
                            temp = s[i].y + (step * r.Next(0, 10) / 10);
                            if (temp >= a && temp <= b)
                            {
                                s[i].y = temp;
                            }
                            else if (temp > a)
                            {
                                s[i].y = a;
                            }
                            else if(temp < b)
                            {
                                s[i].y = b;
                            }
                            else
                            {
                                s[i].y = s[i].y - (step * r.Next(0, 10) / 10);
                            }
                        }
                    }
                    else //Сильная мутация
                    {
                        l = r.Next(0, 11);

                        if(l < 5) //Мутация по x
                        {
                            s[i].x = r.Next(a, b);
                            if (s[i].x < 0)
                            {
                                s[i].x -= r.Next(-1, 10) / 100.00;
                            }
                            else
                            {
                                s[i].x += r.Next(-1, 10) / 100.00;
                            }
                        }
                        else //Мутация по y
                        {
                            s[i].y = r.Next(a, b);
                            if (s[i].y < 0)
                            {
                                s[i].y -= r.Next(-1, 10) / 100.00;
                            }
                            else
                            {
                                s[i].y += r.Next(-1, 10) / 100.00;
                            }
                        }
                    }
                }
                /////////// Конец мутаций

                setFits(); //Пересчитываем значения функции приспособленности
                avgFit = (sMax() - sMin()) / 2.00;

                if (Math.Abs(prevBest - sMax()) <= eps) {
                    found = true;
                } else
                {
                    prevBest = sMax();
                }

                /*
                for (int i = 0; i < s.Count; i++)
                {
                    if(s[i].fit < avgFit)
                    {
                        if(Math.Abs(func(s[i].x, s[i].y) - value) <= eps) //Искомая точка была найдена
                        {
                            result_id = i;
                            found = true;
                        }
                    }
                }
                */
            }
            //////////////////////////////////////////////////////////////////////////

            drawResults();

            console.Clear();
            if(found == true)
            {
                console.AppendText("Количество итераций: " + k + "\n");
                console.AppendText("Количество скрещиваний: " + crossovers + "\n");
                console.AppendText("Количество мутаций: " + mutations + "\n");
                console.AppendText("\n");

                console.AppendText("Найденная точка: (" + s[result_id].x + "; " + s[result_id].y + ")\n");
                console.AppendText("Значение функции в точке: " + func(s[result_id].x, s[result_id].y));


                chart1.Series[3].Points.AddXY(s[result_id].x, s[result_id].y);
                chart1.Series[3].Enabled = true;
            }
            else
            {
                console.AppendText("Количество итераций: " + k + "\n");
                console.AppendText("Количество скрещиваний: " + crossovers + "\n");
                console.AppendText("Количество мутаций: " + mutations + "\n");
                //console.AppendText("Точка, удовлетворяющая требованиям, не была найдена\n");
                console.AppendText("\n");

                result_id = 0;
                temp = s[0].fit;

                for(int i = 0; i < s.Count; i++) //Поиск наилучшей из найденных точек
                {
                    if(s[i].fit <= temp)
                    {
                        result_id = i;
                        temp = s[i].fit;
                    }
                }

                console.AppendText("Наилучшая найденная точка: (" + s[result_id].x + "; " + s[result_id].y + ")\n");
                console.AppendText("Значение функции в точке: " + func(s[result_id].x, s[result_id].y));

                chart1.Series[3].Points.AddXY(s[result_id].x, s[result_id].y);
                chart1.Series[3].Enabled = true;
            }
        }
    }
}
