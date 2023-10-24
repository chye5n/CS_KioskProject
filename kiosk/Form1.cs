using kiosk.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace kiosk
{
    public partial class Form1 : Form
    {
        int randomNumber, buttonnum, buttoncnt;
        int ticketsum, ticketnum;
        int[] ticketarr = new int[4];
        int stringy = 374;
        int SRcnt, Rcnt;
        List<int> seat = new List<int>();
        string[] card = { "카드종류를 선택하세요.", "KB국민카드", "BC카드", "현대카드", "신한카드", "삼성카드", "롯데카드", "NH카드" };
        string[] bank = { "입금하실 은행을 선택하세요.", "농협(중앙)", "국민은행", "우리은행", "기업은행", "신한은행", "우체국", "하나은행" };

        public System.Drawing.Image ResizeP(System.Drawing.Image image)         //이미지 크키 변환(버튼)
        {
            System.Drawing.Size resize = new System.Drawing.Size(47, 20);
            Bitmap resize_image = new Bitmap(image, resize);    //이미지 크기 변환
            return resize_image;
        }

        public System.Drawing.Image ResizeB(System.Drawing.Image image)         //이미지 크기 변환(배경)
        {
            System.Drawing.Size resize = new System.Drawing.Size(1440, 1088);
            Bitmap resize_image = new Bitmap(image, resize);    //이미지 크기 변환
            return resize_image;
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Location = new Point(12, 53);
            panel2.Location = new Point(12, 97);
            panel5.Location = new Point(12, 97);
            panel6.Location = new Point(12, 97);
            label3.ForeColor = Color.Blue;
            label3.Font = new Font(this.Font, FontStyle.Bold);
            label10.BackColor = Color.White;

            timer1.Start();
            for (int i = 1; i <= 132; i++)
            {
                int buttonNumber = i;
                Button? button = this.Controls.Find("button" + buttonNumber.ToString(), true)[0] as Button;
                button.BackColor = Color.BlueViolet;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //공연 날짜 선택
        {
            if (comboBox1.SelectedIndex == 0) { comboBox2.Items.Clear(); comboBox2.Items.Add("19시 00분"); comboBox2.SelectedIndex = 0; }
            if (comboBox1.SelectedIndex == 1) { comboBox2.Items.Clear(); comboBox2.Items.Add("18시 00분"); comboBox2.SelectedIndex = 0; }
            if (comboBox1.SelectedIndex == 2) { comboBox2.Items.Clear(); comboBox2.Items.Add("17시 00분"); comboBox2.SelectedIndex = 0; }
        }

        private void btnseat_Click(object sender, EventArgs e)                  //구역표 보기
        {
            panel1.Visible = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)          //구역 선택
        {
            if ((e.X <= 274) && (e.X >= 214) && (e.Y <= 300) && (e.Y >= 263)) { panel1.Visible = true; label3.Text = "001구역"; }
            if (((e.X <= 278) && (e.X >= 209) && (e.Y <= 343) && (e.Y >= 321)) || ((e.X <= 278) && (e.X >= 222) && (e.Y <= 382) && (e.Y >= 343))) { panel1.Visible = true; label3.Text = "002구역"; }
            if ((e.X <= 333) && (e.X >= 290) && (e.Y <= 388) && (e.Y >= 349)) { panel1.Visible = true; label3.Text = "003구역"; }
            if (((e.X <= 410) && (e.X >= 347) && (e.Y <= 343) && (e.Y >= 321)) || ((e.X <= 391) && (e.X >= 345) && (e.Y <= 382) && (e.Y >= 343))) { panel1.Visible = true; label3.Text = "004구역"; }
            if ((e.X <= 415) && (e.X >= 344) && (e.Y <= 300) && (e.Y >= 263)) { panel1.Visible = true; label3.Text = "005구역"; }
            if ((e.X <= 512) && (e.X >= 424) && (e.Y <= 306) && (e.Y >= 282)) { panel1.Visible = true; label3.Text = "102구역"; }
            if (((e.X <= 512) && (e.X >= 424) && (e.Y <= 343) && (e.Y >= 314)) || ((e.X <= 506) && (e.X >= 465) && (e.Y <= 352) && (e.Y >= 341))) { panel1.Visible = true; label3.Text = "103구역"; }
            if (((e.X <= 451) && (e.X >= 415) && (e.Y <= 378) && (e.Y >= 347)) || ((e.X <= 497) && (e.X >= 446) && (e.Y <= 395) && (e.Y >= 361))) { panel1.Visible = true; label3.Text = "104구역"; }
            if (((e.X <= 419) && (e.X >= 382) && (e.Y <= 403) && (e.Y >= 389)) || ((e.X <= 439) && (e.X >= 397) && (e.Y <= 427) && (e.Y >= 403)) || ((e.X <= 459) && (e.X >= 424) && (e.Y <= 455) && (e.Y >= 427))) { panel1.Visible = true; label3.Text = "105구역"; }
            if (((e.X <= 385) && (e.X >= 361) && (e.Y <= 435) && (e.Y >= 407)) || ((e.X <= 402) && (e.X >= 372) && (e.Y <= 460) && (e.Y >= 435)) || ((e.X <= 420) && (e.X >= 383) && (e.Y <= 488) && (e.Y >= 460))) { panel1.Visible = true; label3.Text = "106구역"; }
            if (((e.X <= 357) && (e.X >= 331) && (e.Y <= 511) && (e.Y >= 419)) || ((e.X <= 368) && (e.X >= 357) && (e.Y <= 504) && (e.Y >= 446))) { panel1.Visible = true; label3.Text = "107구역"; }
            if (((e.X <= 289) && (e.X >= 269) && (e.Y <= 501) && (e.Y >= 419)) || ((e.X <= 269) && (e.X >= 253) && (e.Y <= 503) && (e.Y >= 458))) { panel1.Visible = true; label3.Text = "109구역"; }
            if (((e.X <= 256) && (e.X >= 245) && (e.Y <= 443) && (e.Y >= 403)) || ((e.X <= 245) && (e.X >= 211) && (e.Y <= 486) && (e.Y >= 443))) { panel1.Visible = true; label3.Text = "110구역"; }
            if (((e.X <= 234) && (e.X >= 204) && (e.Y <= 410) && (e.Y >= 389)) || ((e.X <= 204) && (e.X >= 177) && (e.Y <= 446) && (e.Y >= 410)) || ((e.X <= 177) && (e.X >= 168) && (e.Y <= 461) && (e.Y >= 446))) { panel1.Visible = true; label3.Text = "111구역"; }
            if (((e.X <= 179) && (e.X >= 121) && (e.Y <= 395) && (e.Y >= 364)) || ((e.X <= 204) && (e.X >= 149) && (e.Y <= 364) && (e.Y >= 356)) || ((e.X <= 204) && (e.X >= 182) && (e.Y <= 356) && (e.Y >= 344))) { panel1.Visible = true; label3.Text = "112구역"; }
            if (((e.X <= 197) && (e.X >= 110) && (e.Y <= 337) && (e.Y >= 318)) || ((e.X <= 157) && (e.X >= 114) && (e.Y <= 352) && (e.Y >= 337))) { panel1.Visible = true; label3.Text = "113구역"; }
            if ((e.X <= 197) && (e.X >= 112) && (e.Y <= 308) && (e.Y >= 282)) { panel1.Visible = true; label3.Text = "114구역"; }
            if ((e.X <= 96) && (e.X >= 29) && (e.Y <= 351) && (e.Y >= 307)) { panel1.Visible = true; label3.Text = "241구역"; }
            if (((e.X <= 100) && (e.X >= 34) && (e.Y <= 378) && (e.Y >= 361)) || ((e.X <= 86) && (e.X >= 40) && (e.Y <= 402) && (e.Y >= 378))) { panel1.Visible = true; label3.Text = "240구역"; }
            if (((e.X <= 120) && (e.X >= 87) && (e.Y <= 437) && (e.Y >= 403)) || ((e.X <= 87) && (e.X >= 54) && (e.Y <= 459) && (e.Y >= 417))) { panel1.Visible = true; label3.Text = "239구역"; }
            if (((e.X <= 143) && (e.X >= 116) && (e.Y <= 478) && (e.Y >= 460)) || ((e.X <= 116) && (e.X >= 87) && (e.Y <= 506) && (e.Y >= 460))) { panel1.Visible = true; label3.Text = "238구역"; }
            if (((e.X <= 177) && (e.X >= 148) && (e.Y <= 514) && (e.Y >= 474)) || ((e.X <= 148) && (e.X >= 113) && (e.Y <= 538) && (e.Y >= 514))) { panel1.Visible = true; label3.Text = "237구역"; }
            if (((e.X <= 219) && (e.X >= 186) && (e.Y <= 537) && (e.Y >= 501)) || ((e.X <= 206) && (e.X >= 162) && (e.Y <= 570) && (e.Y >= 537))) { panel1.Visible = true; label3.Text = "236구역"; }
            if (((e.X <= 258) && (e.X >= 227) && (e.Y <= 558) && (e.Y >= 519)) || ((e.X <= 227) && (e.X >= 177) && (e.Y <= 560) && (e.Y >= 556))) { panel1.Visible = true; label3.Text = "235구역"; }
            if ((e.X <= 308) && (e.X >= 269) && (e.Y <= 596) && (e.Y >= 528)) { panel1.Visible = true; label3.Text = "234구역"; }
            if ((e.X <= 355) && (e.X >= 313) && (e.Y <= 594) && (e.Y >= 532)) { panel1.Visible = true; label3.Text = "233구역"; }
            if ((e.X <= 403) && (e.X >= 361) && (e.Y <= 580) && (e.Y >= 521)) { panel1.Visible = true; label3.Text = "232구역"; }
            if (((e.X <= 439) && (e.X >= 400) && (e.Y <= 525) && (e.Y >= 507)) || ((e.X <= 452) && (e.X >= 407) && (e.Y <= 566) && (e.Y >= 525))) { panel1.Visible = true; label3.Text = "231구역"; }
            if (((e.X <= 475) && (e.X >= 440) && (e.Y <= 507) && (e.Y >= 478)) || ((e.X <= 505) && (e.X >= 454) && (e.Y <= 526) && (e.Y >= 507))) { panel1.Visible = true; label3.Text = "230구역"; }
            if (((e.X <= 514) && (e.X >= 473) && (e.Y <= 471) && (e.Y >= 445)) || ((e.X <= 536) && (e.X >= 488) && (e.Y <= 493) && (e.Y >= 471))) { panel1.Visible = true; label3.Text = "229구역"; }
            if (((e.X <= 555) && (e.X >= 500) && (e.Y <= 435) && (e.Y >= 410)) || ((e.X <= 568) && (e.X >= 523) && (e.Y <= 448) && (e.Y >= 435))) { panel1.Visible = true; label3.Text = "228구역"; }
            if ((e.X <= 581) && (e.X >= 521) && (e.Y <= 396) && (e.Y >= 355)) { panel1.Visible = true; label3.Text = "227구역"; }
            if ((e.X <= 594) && (e.X >= 527) && (e.Y <= 354) && (e.Y >= 308)) { panel1.Visible = true; label3.Text = "226구역"; }
        }

        public string Seat(string name)                                         //좌석 정보
        {
            switch (name)
            {
                case "button1": return "1열 1번";
                case "button2": return "1열 2번";
                case "button3": return "1열 3번";
                case "button4": return "1열 4번";
                case "button5": return "1열 5번";
                case "button6": return "1열 6번";
                case "button7": return "1열 7번";
                case "button8": return "1열 8번";
                case "button9": return "1열 9번";
                case "button10": return "1열 10번";
                case "button11": return "1열 11번";
                case "button12": return "1열 12번";

                case "button13": return "2열 1번";
                case "button14": return "2열 2번";
                case "button15": return "2열 3번";
                case "button16": return "2열 4번";
                case "button17": return "2열 5번";
                case "button18": return "2열 6번";
                case "button19": return "2열 7번";
                case "button20": return "2열 8번";
                case "button21": return "2열 9번";
                case "button22": return "2열 10번";
                case "button23": return "2열 11번";
                case "button24": return "2열 12번";

                case "button25": return "3열 1번";
                case "button26": return "3열 2번";
                case "button27": return "3열 3번";
                case "button28": return "3열 4번";
                case "button29": return "3열 5번";
                case "button30": return "3열 6번";
                case "button31": return "3열 7번";
                case "button32": return "3열 8번";
                case "button33": return "3열 9번";
                case "button34": return "3열 10번";
                case "button35": return "3열 11번";
                case "button36": return "3열 12번";

                case "button37": return "4열 1번";
                case "button38": return "4열 2번";
                case "button39": return "4열 3번";
                case "button40": return "4열 4번";
                case "button41": return "4열 5번";
                case "button42": return "4열 6번";
                case "button43": return "4열 7번";
                case "button44": return "4열 8번";
                case "button45": return "4열 9번";
                case "button46": return "4열 10번";
                case "button47": return "4열 11번";
                case "button48": return "4열 12번";

                case "button49": return "5열 1번";
                case "button50": return "5열 2번";
                case "button51": return "5열 3번";
                case "button52": return "5열 4번";
                case "button53": return "5열 5번";
                case "button54": return "5열 6번";
                case "button55": return "5열 7번";
                case "button56": return "5열 8번";
                case "button57": return "5열 9번";
                case "button58": return "5열 10번";
                case "button59": return "5열 11번";
                case "button60": return "5열 12번";

                case "button61": return "6열 1번";
                case "button62": return "6열 2번";
                case "button63": return "6열 3번";
                case "button64": return "6열 4번";
                case "button65": return "6열 5번";
                case "button66": return "6열 6번";
                case "button67": return "6열 7번";
                case "button68": return "6열 8번";
                case "button69": return "6열 9번";
                case "button70": return "6열 10번";
                case "button71": return "6열 11번";
                case "button72": return "6열 12번";

                case "button73": return "7열 1번";
                case "button74": return "7열 2번";
                case "button75": return "7열 3번";
                case "button76": return "7열 4번";
                case "button77": return "7열 5번";
                case "button78": return "7열 6번";
                case "button79": return "7열 7번";
                case "button80": return "7열 8번";
                case "button81": return "7열 9번";
                case "button82": return "7열 10번";
                case "button83": return "7열 11번";
                case "button84": return "7열 12번";

                case "button85": return "8열 1번";
                case "button86": return "8열 2번";
                case "button87": return "8열 3번";
                case "button88": return "8열 4번";
                case "button89": return "8열 5번";
                case "button90": return "8열 6번";
                case "button91": return "8열 7번";
                case "button92": return "8열 8번";
                case "button93": return "8열 9번";
                case "button94": return "8열 10번";
                case "button95": return "8열 11번";
                case "button96": return "8열 12번";

                case "button97": return "9열 1번";
                case "button98": return "9열 2번";
                case "button99": return "9열 3번";
                case "button100": return "9열 4번";
                case "button101": return "9열 5번";
                case "button102": return "9열 6번";
                case "button103": return "9열 7번";
                case "button104": return "9열 8번";
                case "button105": return "9열 9번";
                case "button106": return "9열 10번";
                case "button107": return "9열 11번";
                case "button108": return "9열 12번";

                case "button109": return "10열 1번";
                case "button110": return "10열 2번";
                case "button111": return "10열 3번";
                case "button112": return "10열 4번";
                case "button113": return "10열 5번";
                case "button114": return "10열 6번";
                case "button115": return "10열 7번";
                case "button116": return "10열 8번";
                case "button117": return "10열 9번";
                case "button118": return "10열 10번";
                case "button119": return "10열 11번";
                case "button120": return "10열 12번";

                case "button121": return "11열 1번";
                case "button122": return "11열 2번";
                case "button123": return "11열 3번";
                case "button124": return "11열 4번";
                case "button125": return "11열 5번";
                case "button126": return "11열 6번";
                case "button127": return "11열 7번";
                case "button128": return "11열 8번";
                case "button129": return "11열 9번";
                case "button130": return "11열 10번";
                case "button131": return "11열 11번";
                case "button132": return "11열 12번";

                default: return "0";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)                    //랜덤한 좌석 지우기
        {
            Random random = new Random();
            randomNumber = random.Next(1, 133);
            seat.Add(randomNumber);
        }

        private void button_Click(object sender, EventArgs e)                   //좌석 선택
        {
            if (buttonnum > 3) { MessageBox.Show("최대 수량은 4매 입니다."); return; }
            Button clickedButton = sender as Button;
            foreach (int i in seat)
            {
                Button? button = this.Controls.Find("button" + i.ToString(), true)[0] as Button;
                if (button == clickedButton) { MessageBox.Show("이미 선택된 좌석입니다."); }
            }

            if (clickedButton.BackColor == Color.LightGray) { MessageBox.Show("이미 선택된 좌석입니다."); }
            else
            {
                string info = Seat(clickedButton.Name);
                Graphics graphics = CreateGraphics();
                if (clickedButton.BackColor == Color.BlueViolet) { graphics.DrawImage(Resources.SR, new Point(639, stringy)); SRcnt++; }
                if (clickedButton.BackColor == Color.ForestGreen) { graphics.DrawImage(ResizeP(Resources.R1), new Point(639, stringy)); Rcnt++; }
                clickedButton.BackColor = Color.Blue;

                graphics.DrawString(info, Form1.DefaultFont, new SolidBrush(Color.Black), new Point(717, stringy));
                buttonnum++;
                stringy += 18;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)                //좌석선택완료 버튼 선택
        {
            panel2.Visible = true;
            label1.Visible = false;
            label2.Visible = true;
            label19.Visible = true;
            timer1.Stop();
        }

        private void label3_TextChanged(object sender, EventArgs e)             //구역별 좌석 색 변경
        {
            switch (label3.Text)
            {
                case "001구역":
                case "002구역":
                case "003구역":
                case "004구역":
                case "005구역":
                case "105구역":
                case "106구역":
                case "107구역":
                case "109구역":
                case "110구역":
                case "111구역":
                    {
                        for (int i = 1; i <= 132; i++)
                        {
                            int buttonNumber = i;
                            Button? button = this.Controls.Find("button" + buttonNumber.ToString(), true)[0] as Button;
                            if (button.BackColor == Color.ForestGreen) { button.BackColor = Color.BlueViolet; }
                        }
                        break;
                    }
                case "102구역":
                case "103구역":
                case "104구역":
                case "112구역":
                case "113구역":
                case "114구역":
                case "226구역":
                case "227구역":
                case "228구역":
                case "229구역":
                case "230구역":
                case "231구역":
                case "232구역":
                case "233구역":
                case "234구역":
                case "235구역":
                case "236구역":
                case "237구역":
                case "238구역":
                case "239구역":
                case "240구역":
                case "241구역":
                    {
                        for (int i = 1; i <= 132; i++)
                        {
                            int buttonNumber = i;
                            Button? button = this.Controls.Find("button" + buttonNumber.ToString(), true)[0] as Button;
                            if (button.BackColor == Color.BlueViolet) { button.BackColor = Color.ForestGreen; }
                        }
                        break;
                    }
            }
        }

        private void panel2_VisibleChanged(object sender, EventArgs e)          //panel2 = 좌석수 선택
        {
            if (panel2.Visible == true)
            {
                this.BackgroundImage = ResizeB(Resources.구매페이지);
                btnseat.Visible = false;
                btnSelect.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                panel1.Visible = false;
                pictureBox1.Visible = true;
                btnNext.Visible = true;
                label4.Visible = true;
                lbdate.Visible = true;
                lbtime.Visible = true;
                lbpdate1.Visible = true;
                lbpdate2.Visible = true;
                lbCancel.Visible = true;
                lbname1.Visible = true;
                lbname2.Visible = true;
                lbdate.Text = comboBox1.Text;
                lbtime.Text = comboBox2.Text;
                lbCancel.Text = comboBox1.Text + " 00:00 ";
                if (SRcnt != 0)
                {
                    panel3.Visible = true;
                    panel3.Location = new Point(25, 50);
                    label10.Text = "좌석 " + SRcnt + "매";
                    for (int i = 0; i <= SRcnt; i++) { comboBox3.Items.Add(i + "매"); }
                    comboBox3.SelectedIndex = 0;
                }
                if (Rcnt != 0)
                {
                    panel4.Visible = true;
                    for (int i = 0; i <= Rcnt; i++) { comboBox4.Items.Add(i + "매"); }
                    comboBox4.SelectedIndex = 0;
                    label11.Text = "좌석 " + Rcnt + "매";
                    if (panel3.Visible == true) { panel4.Location = new Point(25, 100); }
                    else { panel4.Location = new Point(25, 50); }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) //SR석 좌석수 선택
        {
            ticketarr[0] = comboBox3.SelectedIndex * 143000;
            ticketarr[2] = comboBox3.SelectedIndex * 2000;
            ticketsum = ticketarr[0] + ticketarr[1];
            ticketnum = ticketarr[2] + ticketarr[3];
            lbtp.Text = ticketsum.ToString() + "원";
            lbta.Text = ticketarr[2].ToString() + "원";
            if (ticketsum == 0) { lbtotal.Text = "           "; }
            else { lbtotal.Text = (ticketnum + ticketsum).ToString(); }
            lbtp.Visible = true;
            lbta.Visible = true;
            lbtotal.Visible = true;
            label2.Text = ticketarr[2].ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) //R석 좌석수 선택
        {
            ticketarr[1] = comboBox4.SelectedIndex * 132000;
            ticketarr[3] = comboBox4.SelectedIndex * 2000;
            ticketsum = ticketarr[0] + ticketarr[1];
            ticketnum = ticketarr[2] + ticketarr[3];
            lbtp.Text = ticketsum.ToString() + "원";
            lbta.Text = ticketnum.ToString() + "원";
            if (ticketsum == 0) { lbtotal.Text = "           "; }
            else { lbtotal.Text = (ticketnum + ticketsum).ToString(); }
            lbtp.Visible = true;
            lbta.Visible = true;
            lbtotal.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)                  //다음단계 버튼 선택
        {
            buttoncnt++;
            if (buttoncnt == 1) //좌석수 선택창
            {
                if ((panel3.Visible == false) && (panel4.Visible == true)) { if ((SRcnt + Rcnt) != comboBox4.SelectedIndex) { MessageBox.Show($"{SRcnt + Rcnt}좌석을 선택해야합니다."); buttoncnt--; return; } }
                if ((panel3.Visible == true) && (panel4.Visible == false)) { if ((SRcnt + Rcnt) != comboBox3.SelectedIndex) { MessageBox.Show($"{SRcnt + Rcnt}좌석을 선택해야합니다."); buttoncnt--; return; } }
                if ((panel3.Visible == true) && (panel4.Visible == true)) { if ((SRcnt + Rcnt) != (comboBox3.SelectedIndex + comboBox4.SelectedIndex)) { MessageBox.Show($"{SRcnt + Rcnt}좌석을 선택해야합니다."); buttoncnt--; return; } }

                pictureBox2.Image = Resources._4;
                pictureBox2.Visible = true;
                lbpost.Visible = true;
                panel5.Visible = true;
                panel2.Visible = false;
                panel5.BringToFront();
            }
            if (buttoncnt == 2) //예매자 확인창
            {
                if (textBox1.Text != "010101") { MessageBox.Show("정보가 일치하지 않습니다."); buttoncnt--; return; }  //예매자 일치 정보확인
                else
                {
                    btnNext.Visible = false;
                    btnpay.Visible = true;
                    pictureBox2.Image = Resources._5;
                    panel5.Visible = false;
                    panel6.Visible = true;
                    rdcredit.Checked = true;
                    panel6.BringToFront();
                }
            }
        }

        private void btnpay_Click(object sender, EventArgs e)                   //결제하기 버튼 선택
        {
            if (comboBox5.SelectedIndex == 0)                                   //결제 정보가 없을 경우
            {
                if (rdcredit.Checked) { MessageBox.Show(comboBox5.Text); }
                if (rdpay.Checked) { MessageBox.Show(comboBox5.Text); }
                return;
            }
            else
            {
                if (rdcredit.Checked) { MessageBox.Show($"{comboBox5.Text}로\n{ticketnum + ticketsum}원 결제되었습니다.", "결제완료"); }
                if (rdpay.Checked) { MessageBox.Show($"{comboBox5.Text} '0123456789'으로 {DateTime.Now.AddDays(1).Day}일 00시까지\n{ticketnum + ticketsum}원입금하세요", "결제완료"); }
            }
            Close();
        }

        private void radiobutton_CheckedChanged(object sender, EventArgs e)     //결제 방법 설정
        {
            if (rdcredit.Checked) { comboBox5.Items.Clear(); comboBox5.Items.AddRange(card); }
            if (rdpay.Checked) { lbcredit.Text = "은행명"; comboBox5.Items.Clear(); comboBox5.Items.AddRange(bank); }
            comboBox5.SelectedIndex = 0;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)          //좌석 선택창이 보여질 경우 좌석 색 변경
        {
            if (panel1.Visible == true)
            {
                foreach (int i in seat)
                {
                    Button? button = this.Controls.Find("button" + i.ToString(), true)[0] as Button;
                    button.BackColor = Color.LightGray;
                }
                for (int i = 1; i < 133; i++)
                {
                    Button? button = this.Controls.Find("button" + i.ToString(), true)[0] as Button;
                    if (button.BackColor == Color.Blue) { button.BackColor = Color.LightGray; }
                }
            }
        }
    }
}
