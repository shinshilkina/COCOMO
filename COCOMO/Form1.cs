using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Windows;
using System.IO; 

namespace COCOMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        double a, b, c=2.5, d, pm, tm, size;                                            //для BasicCOCOMO

        double a2, b2, EAF, pm2, tm2, d2;                                               //
        double[] CD = new double[15];                                                   //для IntermediateCOCOMO

        double a3, EAF3,EAF33, pm3, pm33, tm3, E, SF, b3=0.91, c3=3.67, d3=0.28, sced;  //

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 newfrm = new Form3();
            newfrm.Show();
        }

        double[] sf = new double[5];                                                    //
        double[] em = new double[7];                                                    //
        double[] em_det = new double[17];                                               //для COCOMO2
        
        private void strok_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (strok.Text.IndexOf(",") == -1) && (strok.Text.Length != 0)))
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            //
            //BasikCOCOMO
            //
            if (tabControl1.SelectedIndex == 0)
            {
                if (strok.Text != "")
                {
                    size = Convert.ToDouble(strok.Text);
                }
                else MessageBox.Show("Введите число строк кода");
                if (types.Text == "Распространенный")
                {
                    a = 2.4;
                    b = 1.05;
                    d = 0.38;
                }
                else if (types.Text == "Полунезависимый")
                {
                    a = 3;
                    b = 1.12;
                    d = 0.35;
                }
                else if (types.Text == "Встроенный")
                {
                    a = 3.6;
                    b = 1.2;
                    d = 0.32;
                }
                if ((strok.Text != "")&&(types.Text != ""))
                {
                    pm = Math.Round(a * Math.Pow(size, b), 2);
                    tm = Math.Round(c * Math.Pow(pm, d), 2);
                    pm_text.Text = Convert.ToString(pm);
                    tm_text.Text = Convert.ToString("\n" + Math.Round(tm, 2));
                }
            }
            //
            //IntermediateCOCOMO
            //
            else if (tabControl1.SelectedIndex == 1)
            {
                pm2 = 0;
                tm2 = 0;
                EAF = 0;

                if (strok.Text != "")
                {
                    size = Convert.ToDouble(strok.Text);
                    if (types2.Text == "Распространенный")
                    {
                        a2 = 3.2;
                        b2 = 1.05;
                        d2 = 0.38;
                    }
                    else if (types2.Text == "Полунезависимый")
                    {
                        a2 = 3;
                        b2 = 1.12;
                        d2 = 0.35;
                    }
                    else if (types2.Text == "Встроенный")
                    {
                        a2 = 2.8;
                        b2 = 1.2;
                        d2 = 0.32;
                    }

                    if (prod1.Text == "Очень низкий")
                        CD[0] = 0.75;
                    else if (prod1.Text == "Низкий")
                        CD[0] = 0.88;
                    else if (prod1.Text == "Средний")
                        CD[0] = 1;
                    else if (prod1.Text == "Высокий")
                        CD[0] = 1.15;
                    else if (prod1.Text == "Очень высокий")
                        CD[0] = 1.40;

                    if (prod2.Text == "Низкий")
                        CD[1] = 0.94;
                    else if (prod2.Text == "Средний")
                        CD[1] = 1;
                    else if (prod2.Text == "Высокий")
                        CD[1] = 1.08;
                    else if (prod1.Text == "Очень высокий")
                        CD[1] = 1.16;

                    if (prod3.Text == "Очень низкий")
                        CD[2] = 0.7;
                    else if (prod3.Text == "Низкий")
                        CD[2] = 0.85;
                    else if (prod3.Text == "Средний")
                        CD[2] = 1;
                    else if (prod3.Text == "Высокий")
                        CD[2] = 1.15;
                    else if (prod3.Text == "Очень высокий")
                        CD[2] = 1.3;
                    else if (prod3.Text == "Критический")
                        CD[2] = 1.65;

                    if (ao1.Text == "Средний")
                        CD[3] = 1;
                    else if (ao1.Text == "Высокий")
                        CD[3] = 1.11;
                    else if (ao1.Text == "Очень высокий")
                        CD[3] = 1.3;
                    else if (ao1.Text == "Критический")
                        CD[3] = 1.66;

                    if (ao2.Text == "Средний")
                        CD[4] = 1;
                    else if (ao2.Text == "Высокий")
                        CD[4] = 1.06;
                    else if (ao2.Text == "Очень высокий")
                        CD[4] = 1.21;
                    else if (ao2.Text == "Критический")
                        CD[4] = 1.56;

                    if (ao3.Text == "Низкий")
                        CD[5] = 0.87;
                    else if (ao3.Text == "Средний")
                        CD[5] = 1;
                    else if (ao3.Text == "Высокий")
                        CD[5] = 1.15;
                    else if (ao3.Text == "Критический")
                        CD[5] = 1.3;

                    if (ao4.Text == "Низкий")
                        CD[6] = 0.87;
                    else if (ao4.Text == "Средний")
                        CD[6] = 1;
                    else if (ao4.Text == "Высокий")
                        CD[6] = 1.07;
                    else if (ao4.Text == "Очень высокий")
                        CD[6] = 1.15;

                    if (pers1.Text == "Очень низкий")
                        CD[7] = 1.46;
                    else if (pers1.Text == "Низкий")
                        CD[7] = 1.19;
                    else if (pers1.Text == "Средний")
                        CD[7] = 1;
                    else if (pers1.Text == "Высокий")
                        CD[7] = 0.86;
                    else if (pers1.Text == "Очень высокий")
                        CD[7] = 0.71;

                    if (pers2.Text == "Очень низкий")
                        CD[8] = 1.29;
                    else if (pers2.Text == "Низкий")
                        CD[8] = 1.13;
                    else if (pers1.Text == "Средний")
                        CD[8] = 1;
                    else if (pers1.Text == "Высокий")
                        CD[8] = 0.91;
                    else if (pers1.Text == "Очень высокий")
                        CD[8] = 0.82;

                    if (pers3.Text == "Очень низкий")
                        CD[9] = 1.42;
                    else if (pers3.Text == "Низкий")
                        CD[9] = 1.17;
                    else if (pers3.Text == "Средний")
                        CD[9] = 1;
                    else if (pers3.Text == "Высокий")
                        CD[9] = 0.86;
                    else if (pers3.Text == "Очень высокий")
                        CD[9] = 0.7;

                    if (pers4.Text == "Очень низкий")
                        CD[10] = 1.21;
                    else if (pers4.Text == "Низкий")
                        CD[10] = 1.1;
                    else if (pers4.Text == "Средний")
                        CD[10] = 1;
                    else if (pers4.Text == "Высокий")
                        CD[10] = 0.9;

                    if (pers5.Text == "Очень низкий")
                        CD[11] = 1.14;
                    else if (pers5.Text == "Низкий")
                        CD[11] = 1.07;
                    else if (pers5.Text == "Средний")
                        CD[11] = 1;
                    else if (pers5.Text == "Высокий")
                        CD[11] = 0.95;

                    if (proj1.Text == "Очень низкий")
                        CD[12] = 1.24;
                    else if (proj1.Text == "Низкий")
                        CD[12] = 1.1;
                    else if (proj1.Text == "Средний")
                        CD[12] = 1;
                    else if (proj1.Text == "Высокий")
                        CD[12] = 0.91;
                    else if (proj1.Text == "Очень высокий")
                        CD[12] = 0.82;

                    if (proj2.Text == "Очень низкий")
                        CD[13] = 1.24;
                    else if (proj2.Text == "Низкий")
                        CD[13] = 1.1;
                    else if (proj1.Text == "Средний")
                        CD[13] = 1;
                    else if (proj1.Text == "Высокий")
                        CD[13] = 0.91;
                    else if (proj1.Text == "Очень высокий")
                        CD[13] = 0.83;

                    if (proj3.Text == "Очень низкий")
                        CD[14] = 1.23;
                    else if (proj3.Text == "Низкий")
                        CD[14] = 1.08;
                    else if (proj3.Text == "Средний")
                        CD[14] = 1;
                    else if (proj3.Text == "Высокий")
                        CD[14] = 1.04;
                    else if (proj3.Text == "Очень высокий")
                        CD[14] = 1.1;

                    EAF = 1.0;
                    for (int i = 0; i < 15; i++)
                        EAF *= CD[i];

                    if (types2.Text != "")
                    {
                        pm2 = Math.Round(EAF * a2 * Math.Pow(size, b2), 2);
                        tm2 = Math.Round(c * Math.Pow(pm2, d2), 2);
                        pm_text.Text = Convert.ToString(pm2);
                        tm_text.Text = Convert.ToString("\n" + Math.Round(tm2, 2));
                        EAF_tbx.Text = Convert.ToString("\n" + Math.Round(EAF, 2));
                    }
                }
                else MessageBox.Show("Введите число строк кода");
            }
            //
            //COCOMO2
            //
            else if (tabControl1.SelectedIndex == 2)
            {
                pm3 = 0;
                tm3 = 0;
                pm33 = 0;
                E = 0;
                SF = 0;
                em[6] = 0;

                if (strok.Text != "")
                {
                    size = Convert.ToDouble(strok.Text);

                    if (cmb_fac1.Text == "Очень низкий")
                        sf[0] = 6.2;
                    else if (cmb_fac1.Text == "Низкий")
                        sf[0] = 4.96;
                    else if (cmb_fac1.Text == "Средний")
                        sf[0] = 3.72;
                    else if (cmb_fac1.Text == "Высокий")
                        sf[0] = 2.48;
                    else if (cmb_fac1.Text == "Очень высокий")
                        sf[0] = 1.24;

                    if (cmb_fac2.Text == "Очень низкий")
                        sf[1] = 5.07;
                    else if (cmb_fac2.Text == "Низкий")
                        sf[1] = 4.05;
                    else if (cmb_fac2.Text == "Средний")
                        sf[1] = 3.04;
                    else if (cmb_fac2.Text == "Высокий")
                        sf[1] = 2.03;
                    else if (cmb_fac2.Text == "Очень высокий")
                        sf[1] = 1.01;

                    if (cmb_fac3.Text == "Очень низкий")
                        sf[2] = 7.07;
                    else if (cmb_fac3.Text == "Низкий")
                        sf[2] = 5.65;
                    else if (cmb_fac3.Text == "Средний")
                        sf[2] = 4.24;
                    else if (cmb_fac3.Text == "Высокий")
                        sf[2] = 2.83;
                    else if (cmb_fac3.Text == "Очень высокий")
                        sf[2] = 1.41;

                    if (cmb_fac4.Text == "Очень низкий")
                        sf[3] = 5.48;
                    else if (cmb_fac4.Text == "Низкий")
                        sf[3] = 4.38;
                    else if (cmb_fac4.Text == "Средний")
                        sf[3] = 3.29;
                    else if (cmb_fac4.Text == "Высокий")
                        sf[3] = 2.19;
                    else if (cmb_fac4.Text == "Очень высокий")
                        sf[3] = 1.1;

                    if (cmb_fac5.Text == "Очень низкий")
                        sf[4] = 7.8;
                    else if (cmb_fac5.Text == "Низкий")
                        sf[4] = 6.24;
                    else if (cmb_fac5.Text == "Средний")
                        sf[4] = 4.68;
                    else if (cmb_fac5.Text == "Высокий")
                        sf[4] = 3.12;
                    else if (cmb_fac5.Text == "Очень высокий")
                        sf[4] = 1.56;
                    if (strok.Text != "")
                    for (int i = 0; i < 5; i++)
                        SF += sf[i];

                    E = b3 + 0.01 * SF;
                    if (strok.Text != "")
                    {
                        sf_tbx.Text = Convert.ToString("\n" + Math.Round(SF, 2));
                    }

                    if (cmb_stad.Text == "Предварительная оценка")
                    {
                        sced = 0;
                        a3 = 2.94;
                        EAF3 = 1;
                        EAF33 = 1;
                        //множители пред

                        if (cmb_mnoz1.Text == "Критически низкий")
                            em[0] = 2.12;
                        else if (cmb_mnoz1.Text == "Очень низкий")
                            em[0] = 1.62;
                        else if (cmb_mnoz1.Text == "Низкий")
                            em[0] = 1.26;
                        else if (cmb_mnoz1.Text == "Средний")
                            em[0] = 1;
                        else if (cmb_mnoz1.Text == "Высокий")
                            em[0] = 0.83;
                        else if (cmb_mnoz1.Text == "Очень высокий")
                            em[0] = 0.63;
                        else if (cmb_mnoz1.Text == "Критически высокий")
                            em[0] = 0.5;

                        if (cmb_mnoz11.Text == "Критически низкий")
                            em[1] = 1.59;
                        else if (cmb_mnoz11.Text == "Очень низкий")
                            em[1] = 1.33;
                        else if (cmb_mnoz11.Text == "Низкий")
                            em[1] = 1.22;
                        else if (cmb_mnoz11.Text == "Средний")
                            em[1] = 1;
                        else if (cmb_mnoz11.Text == "Высокий")
                            em[1] = 0.87;
                        else if (cmb_mnoz11.Text == "Очень высокий")
                            em[1] = 0.74;
                        else if (cmb_mnoz11.Text == "Критически высокий")
                            em[1] = 0.62;

                        if (cmb_mnoz3.Text == "Критически низкий")
                            em[2] = 0.49;
                        else if (cmb_mnoz3.Text == "Очень низкий")
                            em[2] = 0.6;
                        else if (cmb_mnoz3.Text == "Низкий")
                            em[2] = 0.83;
                        else if (cmb_mnoz3.Text == "Средний")
                            em[2] = 1;
                        else if (cmb_mnoz3.Text == "Высокий")
                            em[2] = 1.33;
                        else if (cmb_mnoz3.Text == "Очень высокий")
                            em[2] = 1.91;
                        else if (cmb_mnoz3.Text == "Критически высокий")
                            em[2] = 2.72;

                        if (cmb_mnoz4.Text == "Низкий")
                            em[3] = 0.95;
                        else if (cmb_mnoz4.Text == "Средний")
                            em[3] = 1;
                        else if (cmb_mnoz4.Text == "Высокий")
                            em[3] = 1.07;
                        else if (cmb_mnoz4.Text == "Очень высокий")
                            em[3] = 1.15;
                        else if (cmb_mnoz4.Text == "Критически высокий")
                            em[3] = 1.24;

                        if (cmb_mnoz5.Text == "Низкий")
                            em[4] = 0.87;
                        else if (cmb_mnoz5.Text == "Средний")
                            em[4] = 1;
                        else if (cmb_mnoz5.Text == "Высокий")
                            em[4] = 1.29;
                        else if (cmb_mnoz5.Text == "Очень высокий")
                            em[4] = 1.81;
                        else if (cmb_mnoz5.Text == "Критически высокий")
                            em[4] = 2.61;

                        if (cmb_mnoz6.Text == "Критически низкий")
                            em[5] = 1.43;
                        else if (cmb_mnoz6.Text == "Очень низкий")
                            em[5] = 1.3;
                        else if (cmb_mnoz6.Text == "Низкий")
                            em[5] = 1.1;
                        else if (cmb_mnoz6.Text == "Средний")
                            em[5] = 1;
                        else if (cmb_mnoz6.Text == "Высокий")
                            em[5] = 0.87;
                        else if (cmb_mnoz6.Text == "Очень высокий")
                            em[5] = 0.73;
                        else if (cmb_mnoz6.Text == "Критически высокий")
                            em[5] = 0.62;

                        if (cmb_mnoz7.Text == "Очень низкий")
                            em[6] = 1.43;
                        else if (cmb_mnoz7.Text == "Низкий")
                            em[6] = 1.14;
                        else if (cmb_mnoz7.Text == "Средний")
                            em[6] = 1;
                        else if (cmb_mnoz7.Text == "Высокий")
                            em[6] = 1;

                        sced = em[6];

                        for (int i = 0; i < 7; i++)
                            EAF3 *= em[i];

                        for (int i = 0; i < 6; i++)
                            EAF33 *= em[i];

                    }
                    //множители детал
                    else if (cmb_stad.Text == "Детальная оценка")
                    {
                        a3 = 2.45;
                        EAF3 = 1;
                        EAF33 = 1;
                        sced = 0;

                        switch (cmb_mnoz_det1.Text)
                        {
                            case "Очень низкий":
                                em_det[0] = 1.42;
                                break;
                            case "Низкий":
                                em_det[0] = 1.29;
                                break;
                            case "Высокий":
                                em_det[0] = 0.85;
                                break;
                            case "Очень высокий":
                                em_det[0] = 0.71;
                                break;
                            default:
                                em_det[0] = 1;
                                break;
                        }

                        switch (cmb_mnoz_det2.Text)
                        {
                            case "Очень низкий":
                                em_det[1] = 1.22;
                                break;
                            case "Низкий":
                                em_det[1] = 1.1;
                                break;
                            case "Высокий":
                                em_det[1] = 0.88;
                                break;
                            case "Очень высокий":
                                em_det[1] = 0.81;
                                break;
                            default:
                                em_det[1] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det3.Text)
                        {
                            case "Очень низкий":
                                em_det[2] = 1.34;
                                break;
                            case "Низкий":
                                em_det[2] = 1.15;
                                break;
                            case "Высокий":
                                em_det[2] = 0.88;
                                break;
                            case "Очень высокий":
                                em_det[2] = 0.76;
                                break;
                            default:
                                em_det[2] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det4.Text)
                        {
                            case "Очень низкий":
                                em_det[3] = 1.29;
                                break;
                            case "Низкий":
                                em_det[3] = 1.12;
                                break;
                            case "Высокий":
                                em_det[3] = 0.9;
                                break;
                            case "Очень высокий":
                                em_det[3] = 0.81;
                                break;
                            default:
                                em_det[3] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det5.Text)
                        {
                            case "Очень низкий":
                                em_det[4] = 1.19;
                                break;
                            case "Низкий":
                                em_det[4] = 1.09;
                                break;
                            case "Высокий":
                                em_det[4] = 0.91;
                                break;
                            case "Очень высокий":
                                em_det[4] = 0.85;
                                break;
                            default:
                                em_det[4] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det6.Text)
                        {
                            case "Очень низкий":
                                em_det[5] = 1.2;
                                break;
                            case "Низкий":
                                em_det[5] = 1.09;
                                break;
                            case "Высокий":
                                em_det[5] = 0.91;
                                break;
                            case "Очень высокий":
                                em_det[5] = 0.84;
                                break;
                            default:
                                em_det[5] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det7.Text)
                        {
                            case "Очень низкий":
                                em_det[6] = 0.84;
                                break;
                            case "Низкий":
                                em_det[6] = 0.92;
                                break;
                            case "Высокий":
                                em_det[6] = 1.1;
                                break;
                            case "Очень высокий":
                                em_det[6] = 1.26;
                                break;
                            default:
                                em_det[6] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det8.Text)
                        {
                            case "Низкий":
                                em_det[7] = 0.23;
                                break;
                            case "Высокий":
                                em_det[7] = 1.14;
                                break;
                            case "Очень высокий":
                                em_det[7] = 1.28;
                                break;
                            default:
                                em_det[7] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det9.Text)
                        {
                            case "Очень низкий":
                                em_det[8] = 0.73;
                                break;
                            case "Низкий":
                                em_det[8] = 0.87;
                                break;
                            case "Высокий":
                                em_det[8] = 1.17;
                                break;
                            case "Очень высокий":
                                em_det[8] = 1.34;
                                break;
                            case "Критически высокий":
                                em_det[8] = 1.74;
                                break;
                            default:
                                em_det[8] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det10.Text)
                        {
                            case "Низкий":
                                em_det[9] = 0.95;
                                break;
                            case "Высокий":
                                em_det[9] = 1.07;
                                break;
                            case "Очень высокий":
                                em_det[9] = 1.15;
                                break;
                            case "Критически высокий":
                                em_det[9] = 1.24;
                                break;
                            default:
                                em_det[9] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det11.Text)
                        {
                            case "Очень низкий":
                                em_det[10] = 0.81;
                                break;
                            case "Низкий":
                                em_det[10] = 0.91;
                                break;
                            case "Высокий":
                                em_det[10] = 1.11;
                                break;
                            case "Очень высокий":
                                em_det[10] = 1.23;
                                break;
                            default:
                                em_det[10] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det12.Text)
                        {
                            case "Высокий":
                                em_det[11] = 1.11;
                                break;
                            case "Очень высокий":
                                em_det[11] = 1.29;
                                break;
                            case "Критически высокий":
                                em_det[11] = 1.63;
                                break;
                            default:
                                em_det[11] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det13.Text)
                        {
                            case "Высокий":
                                em_det[12] = 1.05;
                                break;
                            case "Очень высокий":
                                em_det[12] = 1.17;
                                break;
                            case "Критически высокий":
                                em_det[12] = 1.46;
                                break;
                            default:
                                em_det[12] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det15.Text)
                        {
                            case "Низкий":
                                em_det[13] = 0.87;
                                break;
                            case "Высокий":
                                em_det[13] = 1.15;
                                break;
                            case "Очень высокий":
                                em_det[13] = 1.3;
                                break;
                            default:
                                em_det[13] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det16.Text)
                        {
                            case "Очень низкий":
                                em_det[14] = 1.17;
                                break;
                            case "Низкий":
                                em_det[14] = 1.09;
                                break;
                            case "Высокий":
                                em_det[14] = 0.9;
                                break;
                            case "Очень высокий":
                                em_det[14] = 0.78;
                                break;
                            default:
                                em_det[14] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det17.Text)
                        {
                            case "Очень низкий":
                                em_det[15] = 1.22;
                                break;
                            case "Низкий":
                                em_det[15] = 1.09;
                                break;
                            case "Высокий":
                                em_det[15] = 0.93;
                                break;
                            case "Очень высокий":
                                em_det[15] = 0.86;
                                break;
                            case "Критически высокий":
                                em_det[15] = 0.8;
                                break;
                            default:
                                em_det[15] = 1;
                                break;
                        }
                        switch (cmb_mnoz_det14.Text)
                        {
                            case "Очень низкий":
                                em_det[16] = 1.43;
                                break;
                            case "Низкий":
                                em_det[16] = 1.14;
                                break;
                            case "Высокий":
                                em_det[16] = 1;
                                break;
                            case "Очень высокий":
                                em_det[16] = 1;
                                break;
                            default:
                                em_det[16] = 1;
                                break;
                        }
                        sced = em_det[16];

                        for (int i = 0; i < 17; i++)
                            EAF3 *= em_det[i];

                        for (int i = 0; i < 16; i++)
                            EAF33 *= em_det[i];
                    }
                    if (strok.Text != "")
                    {
                        pm3 = Math.Round(EAF3 * a3 * Math.Pow(size, E), 2);
                        pm_text.Text = Convert.ToString("\n" + Math.Round(pm3, 2));
                        pm33 = EAF33 * a3 * Math.Pow(size, E);
                        tm3 = Math.Round(sced * c3 * Math.Pow(pm33, d3 + 0.2 * (E - b3)), 2);
                        tm_text.Text = Convert.ToString("\n" + Math.Round(tm3, 2));
                        EAF_tbx.Text = Convert.ToString("\n" + Math.Round(EAF3, 2));
                    }
                }
                else MessageBox.Show("Введите число строк кода");
            }
        }
        private void cmb_stad_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl3.Enabled = true;
            if (cmb_stad.Text == "Предварительная оценка")
            {
                panel_pred.Visible = true;
                panel_detal.Visible = false;
                cmb_fac1.Text = Convert.ToString(cmb_fac1.Items[2]);
                cmb_fac2.Text = Convert.ToString(cmb_fac2.Items[2]);
                cmb_fac3.Text = Convert.ToString(cmb_fac3.Items[2]);
                cmb_fac4.Text = Convert.ToString(cmb_fac4.Items[2]);
                cmb_fac5.Text = Convert.ToString(cmb_fac5.Items[2]);
                cmb_mnoz1.Text = Convert.ToString(cmb_mnoz1.Items[3]);
                cmb_mnoz11.Text = Convert.ToString(cmb_mnoz11.Items[3]);
                cmb_mnoz3.Text = Convert.ToString(cmb_mnoz3.Items[3]);
                cmb_mnoz4.Text = Convert.ToString(cmb_mnoz4.Items[1]);
                cmb_mnoz5.Text = Convert.ToString(cmb_mnoz5.Items[1]);
                cmb_mnoz6.Text = Convert.ToString(cmb_mnoz6.Items[3]);
                cmb_mnoz7.Text = Convert.ToString(cmb_mnoz7.Items[2]);
            }
            if (cmb_stad.Text == "Детальная оценка")
            {
                panel_pred.Visible = false;
                panel_detal.Visible = true;
                cmb_fac1.Text = Convert.ToString(cmb_fac1.Items[2]);
                cmb_fac2.Text = Convert.ToString(cmb_fac1.Items[2]);
                cmb_fac3.Text = Convert.ToString(cmb_fac1.Items[2]);
                cmb_fac4.Text = Convert.ToString(cmb_fac1.Items[2]);
                cmb_fac5.Text = Convert.ToString(cmb_fac1.Items[2]);
                cmb_mnoz_det1.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det2.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det3.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det4.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det5.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det6.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det7.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det8.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det9.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det10.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det11.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det12.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det13.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det14.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det15.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det16.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
                cmb_mnoz_det17.Text = Convert.ToString(cmb_mnoz_det1.Items[2]);
            }
        }
        private void types2_SelectedIndexChanged(object sender, EventArgs e)
                {
                    tabControl2.Enabled = true;
                    prod1.Text = Convert.ToString(prod1.Items[2]);
                    prod2.Text = Convert.ToString(prod1.Items[2]);
                    prod3.Text = Convert.ToString(prod1.Items[2]);
                    ao1.Text = Convert.ToString(prod1.Items[2]);
                    ao2.Text = Convert.ToString(prod1.Items[2]);
                    ao3.Text = Convert.ToString(prod1.Items[2]);
                    ao4.Text = Convert.ToString(prod1.Items[2]);
                    pers1.Text = Convert.ToString(prod1.Items[2]);
                    pers2.Text = Convert.ToString(prod1.Items[2]);
                    pers3.Text = Convert.ToString(prod1.Items[2]);
                    pers4.Text = Convert.ToString(prod1.Items[2]);
                    pers5.Text = Convert.ToString(prod1.Items[2]);
                    proj1.Text = Convert.ToString(prod1.Items[2]);
                    proj2.Text = Convert.ToString(prod1.Items[2]);
                    proj3.Text = Convert.ToString(prod1.Items[2]);
                }
        
        private void About_Click(object sender, EventArgs e)
        {
            About r = new About();
            r.Show();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            tm_text.Text = "";
            pm_text.Text = "";
            strok.Text = "";
            EAF_tbx.Text = "";
            sf_tbx.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(PREC, "Прецедентность, наличие опыта аналогичных разработок");
           
            t.SetToolTip(FLEX, "Гибкость процесса разработки");

            t.SetToolTip(RESL, "Архитектура и разрешение рисков");
            t.SetToolTip(TEAM, "Сработанность команды");
            t.SetToolTip(PMAT, "Зрелость процессов");
            t.SetToolTip(label55, "Возможности аналитика");
            t.SetToolTip(label56, "Oпыт разработки приложений");
            t.SetToolTip(label50, "Возможности программиста");
            t.SetToolTip(label49, "Продолжительность работы персонала");
            t.SetToolTip(label48, "Опыт работы с платформой");
            t.SetToolTip(label47, "Опыт использования языка программирования и инструментальных средств");
            t.SetToolTip(label46, "Требуемая надежность программы");
            t.SetToolTip(label59, "Размер базы данных");
            t.SetToolTip(label58, "Сложность программы");
            t.SetToolTip(label57, "Требуемая возможность многократного использования");
            t.SetToolTip(label68, "Соответствие документации потребностям жизненного цикла");
            t.SetToolTip(label69, "Ограничения времени выполнения");
            t.SetToolTip(label67, "Ограничения памяти");
            t.SetToolTip(label65, "Изменяемость платформы");
            t.SetToolTip(label64, "Использование инструментальных программных средств");
            t.SetToolTip(label63, "Иногоабонентская (удаленная) разработка");
            t.SetToolTip(label66, "Требуемое выполнение графика работ");
             }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void prod3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            About newfrm = new About();
            newfrm.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
          
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            using ( FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\Help1.pdf", FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                   // binaryWriter.Write(Properties.Resources.);
                }
            }
            Process.Start(Environment.CurrentDirectory + "\\Help1.pdf");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form3 newfrm = new Form3();
            newfrm.Show();
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form3 newfrm = new Form3();
            newfrm.Show();
        }

        
      /*  private void open_close_Click(object sender, EventArgs e)
        {
            if (k == 0)
            {
                this.Width = 727;
                open_close.Text = "<< Спрятать";
                k++;
            }
            else if (k==1)
            {
                this.Width = 307;
                open_close.Text = "Настройки >>";
                k--;
            }
        }

        private void Show_Help_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start("справка1.pdf");

       */

    }
}
