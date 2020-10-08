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
using ClassLibraryBikesBusLayer;
using ClassLibraryBikesDataLayer;

namespace BikesPresentationLayer
{
    public partial class MyBikes : Form
    {
        int indexMountain = -1;
        int indexRoad = -1;
        int positionColor = -1;
        int positionSuspension = -1;
        
        List<MountainBike> mountainList = new List<MountainBike>();
        List<RoadBike> roadList = new List<RoadBike>();

        List<Bike> listOfBikes;

        public MyBikes()
        {
            InitializeComponent();
        }

        //****** Bikes Split ******//
        public void SplittingListOffBikes()
        {
            foreach (Bike element in listOfBikes)
            {
                if (element is MountainBike)
                {
                    mountainList.Add((MountainBike) element);
                    listBoxMountain.Items.Add(element);
                }
                else if (element is RoadBike)
                {
                    roadList.Add((RoadBike) element);
                    listBoxRoad.Items.Add(element);
                }
            }
        }

        //****** Display List of Mountain Bikes ******//
        private void buttonDisplayMountain_Click(object sender, EventArgs e)
        {
            listBoxMountain.Items.Clear();
            if (mountainList.Count > 0)
            {
                foreach (MountainBike element in mountainList)
                {
                    listBoxMountain.Items.Add(element);
                }
            }
            else
            { MessageBox.Show("Mountain list is empty"); }
        }

        //****** Display List of Road Bikes ******//
        private void buttonDisplayRoad_Click(object sender, EventArgs e)
        {
            listBoxRoad.Items.Clear();
            if(roadList.Count > 0)
            {
                foreach (RoadBike element in roadList)
                {
                    listBoxRoad.Items.Add(element);
                }
            }
            else
            { MessageBox.Show("Road list is empty"); }
        }

        //****** MyBikes Form-Load ******//
        private void MyBikes_Load(object sender, EventArgs e)
        {
            this.radioButtonMountain.Checked = this.labelHeight.Enabled = textBoxHeight.Enabled = labelSuspension.Enabled
                = comboBoxSuspension.Enabled = this.labelStar1.Enabled = this.labelStar2.Enabled = false;
            this.radioButtonRoad.Checked = this.labelSeatHeight.Enabled = textBoxSeatHeight.Enabled = labelWheelSize.Enabled
                = textBoxWheelSize.Enabled = this.labelStar3.Enabled = this.labelStar4.Enabled = false;

            foreach (EnumColor item in Enum.GetValues(typeof(EnumColor)))
            {
                this.comboBoxColor.Items.Add(item);
            }
            this.comboBoxColor.Text = Convert.ToString(this.comboBoxColor.Items[3]);

            foreach (EnumSuspension item in Enum.GetValues(typeof(EnumSuspension)))
            {
                this.comboBoxSuspension.Items.Add(item);
            }
            this.comboBoxSuspension.Text = Convert.ToString(this.comboBoxSuspension.Items[3]);
            textBoxSN.Focus();
            listOfBikes = new List<Bike>();
            //listOfBikes = FileHandler.ReadFromBinary();
        }

        //****** EXIT ******//
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("\n Are you sure you want to exit the application?", "EXIT",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("\n Thank you for using my application! \n Created by: ** Mina Dawood **");
                this.Close();
            }
        }

        //****** Mountain Bike ******//
        private void radioButtonMountain_CheckedChanged(object sender, EventArgs e)
        {
            if(this.radioButtonMountain.Checked)
            {
                this.radioButtonMountain.Checked = this.labelHeight.Enabled = textBoxHeight.Enabled = labelSuspension.Enabled
                = comboBoxSuspension.Enabled = this.labelStar1.Enabled = this.labelStar2.Enabled = true;
                this.radioButtonRoad.Checked = this.labelSeatHeight.Enabled = textBoxSeatHeight.Enabled = labelWheelSize.Enabled
                = textBoxWheelSize.Enabled = this.labelStar3.Enabled = this.labelStar4.Enabled = false;
                textBoxHeight.Focus();
            }
        }

        //****** Road Bike ******//
        private void radioButtonRoad_CheckedChanged(object sender, EventArgs e)
        {
            if(this.radioButtonRoad.Checked)
            {
                this.radioButtonMountain.Checked = this.labelHeight.Enabled = textBoxHeight.Enabled = labelSuspension.Enabled
                = comboBoxSuspension.Enabled = this.labelStar1.Enabled = this.labelStar2.Enabled = false;
                this.radioButtonRoad.Checked = this.labelSeatHeight.Enabled = textBoxSeatHeight.Enabled = labelWheelSize.Enabled
                    = textBoxWheelSize.Enabled = this.labelStar3.Enabled = this.labelStar4.Enabled = true;
                textBoxSeatHeight.Focus();
            }
        }

        //****** ComboBox Color ******//
        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.positionColor = comboBoxColor.SelectedIndex;
        }

        //****** ComboBox Suspension ******//
        private void comboBoxSuspension_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.positionSuspension = comboBoxSuspension.SelectedIndex;
        }

        //****** List Box Mountains ******//
        private void listBoxMountain_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexMountain = this.listBoxMountain.SelectedIndex;

            this.radioButtonMountain.Checked = this.labelHeight.Enabled = textBoxHeight.Enabled = labelSuspension.Enabled
                = comboBoxSuspension.Enabled = this.labelStar1.Enabled = this.labelStar2.Enabled = true;
            this.radioButtonRoad.Checked = this.labelSeatHeight.Enabled = textBoxSeatHeight.Enabled = labelWheelSize.Enabled
                = textBoxWheelSize.Enabled = this.labelStar3.Enabled = this.labelStar4.Enabled = false;

            this.textBoxSN.Text = Convert.ToString(this.mountainList[indexMountain].SerialNumber);
            this.mountainList[indexMountain].Type = EnumBikesType.Mountain_Bikes;
            this.textBoxMake.Text = this.mountainList[indexMountain].Make;
            this.textBoxSpeed.Text = Convert.ToString(this.mountainList[indexMountain].Speed);
            this.comboBoxColor.Text = Convert.ToString(this.mountainList[indexMountain].Color);
            this.textBoxPrice.Text = Convert.ToString(this.mountainList[indexMountain].Price);
            this.textBoxHeight.Text = Convert.ToString(this.mountainList[indexMountain].Height);
            this.comboBoxSuspension.Text = Convert.ToString(this.mountainList[indexMountain].Suspension);
            this.dateTimePickerDate.Text = Convert.ToString(mountainList[indexMountain].Date);
        }

        //****** List Box Roads ******//
        private void listBoxRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexRoad = this.listBoxRoad.SelectedIndex;

            this.radioButtonMountain.Checked = this.labelHeight.Enabled = textBoxHeight.Enabled = labelSuspension.Enabled
                = comboBoxSuspension.Enabled = this.labelStar1.Enabled = this.labelStar2.Enabled = false;
            this.radioButtonRoad.Checked = this.labelSeatHeight.Enabled = textBoxSeatHeight.Enabled = labelWheelSize.Enabled
                = textBoxWheelSize.Enabled = this.labelStar3.Enabled = this.labelStar4.Enabled = true;

            this.textBoxSN.Text = Convert.ToString(this.roadList[indexRoad].SerialNumber);
            this.roadList[indexRoad].Type = EnumBikesType.Road_Bikes;
            this.textBoxMake.Text = this.roadList[indexRoad].Make;
            this.textBoxSpeed.Text = Convert.ToString(this.roadList[indexRoad].Speed);
            this.comboBoxColor.Text = Convert.ToString(this.roadList[indexRoad].Color);
            this.textBoxPrice.Text = Convert.ToString(this.roadList[indexRoad].Price);
            this.labelSeatHeight.Text = Convert.ToString(this.roadList[indexRoad].Seatheight);
            this.textBoxWheelSize.Text = Convert.ToString(this.roadList[indexRoad].WheelSize);
            this.dateTimePickerDate.Text = Convert.ToString(roadList[indexRoad].Date);

            //dateTimePickerDate.Value = DateTime.Parse(Convert.ToString(listOfBikes[indexRoad].Date));
        }

        //****** Clear Controls Method ******//
        public void ClearControls()
        {
            foreach (Control control in Controls)
            {
                this.textBoxHeight.Text = "";
                this.textBoxSeatHeight.Text = "";
                this.textBoxWheelSize.Text = "";
                if (control is TextBox)
                {
                    control.Text = "";
                    this.radioButtonMountain.Checked = this.labelHeight.Enabled = textBoxHeight.Enabled = labelSuspension.Enabled
                        = comboBoxSuspension.Enabled = this.labelStar1.Enabled = this.labelStar2.Enabled = false;
                    this.radioButtonRoad.Checked = this.labelSeatHeight.Enabled = textBoxSeatHeight.Enabled = labelWheelSize.Enabled
                        = textBoxWheelSize.Enabled = this.labelStar3.Enabled = this.labelStar4.Enabled = false;
                    this.comboBoxColor.Text = Convert.ToString(this.comboBoxColor.Items[3]);
                    this.comboBoxSuspension.Text = Convert.ToString(this.comboBoxSuspension.Items[3]);
                    this.dateTimePickerDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                }
            }
            textBoxSN.Focus();
            listBoxMountain.Items.Clear();
            listBoxRoad.Items.Clear();
        }

        //****** Reset ******//
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        //****** WRITE TO BINARY FILE ******// OR //****** WRITE TO XML FILE ******//
        private void buttonWriteToFile_Click(object sender, EventArgs e)
        {
            //FileHandler.WriteToBinaryFile(listOfBikes);
            FileHandler.WriteToXmlFile(listOfBikes);
        }

        //****** READ FROM BINARY FILE ******// OR //****** READ FROM XML FILE ******//
        private void buttonReadFromFile_Click(object sender, EventArgs e)
        {
            this.listBoxMountain.Items.Clear();
            this.listBoxRoad.Items.Clear();
            /*if (File.Exists(FileHandler.binFilePath))
            {
                List<Bike> listFromFile = new List<Bike>();
                listFromFile = FileHandler.ReadFromBinary();

                listOfBikes = listFromFile;
                if (radioButtonMountain.Checked)
                { this.listBoxMountain.Items.Add(listFromFile); }
                if (radioButtonRoad.Checked)
                { this.listBoxRoad.Items.Add(listFromFile); }

                MessageBox.Show("Content loaded..");
            }
            else
            { MessageBox.Show("No data found.."); }*/

            List<Bike> list;
            listBoxMountain.Items.Clear();
            listBoxRoad.Items.Clear();
            list = FileHandler.ReadFromXmlFile();
            if (File.Exists(FileHandler.xmlFilePath))
            {
                if (list.Count > 0)
                {
                    SplittingListOffBikes();
                    MessageBox.Show("Content loaded..");
                }
                else
                { MessageBox.Show("No data found.."); }
            }
        }

        //****** ADD ******//
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            long sn;
            EnumBikesType type;
            string make;
            double speed;
            EnumColor color;
            DateTime date;
            double price;
            EnumSuspension suspension;
            double height;
            double seatHeight;
            double wheelSize;

            bool correct = false;
            string input;

            Bike aBike;

            if (radioButtonMountain.Checked)
            {
                //****** RegEx Validator ******//
                do
                {
                    input = textBoxSN.Text;
                    if (RegExValidator.Is12Digit(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT 12 DIGITS FOR SERIAL NUMBER!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxMake.Text;
                    if (RegExValidator.IsAlphabetLetter(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT ONLY CHARACTERS FOR MAKE!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxSpeed.Text;
                    if (RegExValidator.IsDecimal(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DECIMAL NUMBER FOR SPEED!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxHeight.Text;
                    if (RegExValidator.IsDecimal(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DECIMAL NUMBER FOR HEIGHT!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxPrice.Text;
                    if (RegExValidator.IsEmpty(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DATA FOR PRICE!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                sn = Convert.ToInt64(textBoxSN.Text);
                make = this.textBoxMake.Text;
                type = EnumBikesType.Mountain_Bikes;
                speed = Convert.ToDouble(this.textBoxSpeed.Text);
                color = (EnumColor)positionColor;
                date = DateTime.Parse(dateTimePickerDate.Text);
                price = Convert.ToDouble(this.textBoxPrice.Text);
                suspension = (EnumSuspension)positionSuspension;
                height = Convert.ToDouble(textBoxHeight.Text);

                aBike = new MountainBike(sn, type, make, speed, color, date, price, suspension, height);
                listOfBikes.Add(aBike);
                mountainList.Add((MountainBike)aBike);
                ClearControls();
                listBoxMountain.Items.Add(aBike);
            }
                else if (radioButtonRoad.Checked)
                {
                //****** Validation ******//
                correct = false;
                do
                {
                    input = textBoxSN.Text;
                    if (RegExValidator.Is12Digit(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT 12 DIGITS FOR SERIAL NUMBER!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxMake.Text;
                    if (RegExValidator.IsAlphabetLetter(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT ONLY CHARACTERS FOR MAKE!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxSpeed.Text;
                    if (RegExValidator.IsDecimal(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DECIMAL NUMBER FOR SPEED!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxSeatHeight.Text;
                    if (RegExValidator.IsDecimal(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DECIMAL NUMBER FOR SEAT HEIGHT!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxPrice.Text;
                    if (RegExValidator.IsEmpty(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DATA FOR PRICE!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                correct = false;
                do
                {
                    input = textBoxWheelSize.Text;
                    if (RegExValidator.IsEmpty(input))
                    {
                        correct = true;
                        continue;
                    }
                    if (!correct) MessageBox.Show("YOU MUST INPUT DATA FOR WHEEL SIZE!",
                                                    "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                } while (!correct);

                sn = Convert.ToInt64(this.textBoxSN.Text);
                    type = EnumBikesType.Road_Bikes;
                    make = this.textBoxMake.Text;
                    speed = Convert.ToDouble(this.textBoxSpeed.Text);
                    color = (EnumColor)positionColor;
                    price = Convert.ToDouble(this.textBoxPrice.Text);
                    date = DateTime.Parse(dateTimePickerDate.Text);
                    seatHeight = Convert.ToDouble(textBoxSeatHeight.Text);
                    wheelSize = Convert.ToDouble(textBoxWheelSize.Text);

                    aBike = new RoadBike(sn, type, make, speed, color, date, price, seatHeight, wheelSize);
                    listOfBikes.Add(aBike);
                    roadList.Add((RoadBike)aBike);
                    ClearControls();
                    listBoxRoad.Items.Add(aBike);
            }
        }

        //****** Remove ******//
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to delete this Bike? ", "DELETE",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (indexMountain >= 0) { mountainList.RemoveAt(indexMountain); }
                if (indexRoad >= 0) { roadList.RemoveAt(indexRoad); }
                //ClearControls();
            }
            else MessageBox.Show("The list has NOT Changed ....");
        }

        //****** Update ******//
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            long sn;
            EnumBikesType type;
            string make;
            double speed;
            EnumColor color;
            DateTime date;
            double price;
            EnumSuspension suspension;
            double height;
            double seatHeight;
            double wheelSize;

            DialogResult result;
            result = MessageBox.Show("Are you sure you want to update this item? ", "UPDATE",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (radioButtonMountain.Checked)
                {
                    sn = Convert.ToInt64(this.textBoxSN.Text);
                    type = EnumBikesType.Mountain_Bikes;
                    make = this.textBoxMake.Text;
                    speed = Convert.ToDouble(this.textBoxSpeed.Text);
                    color = (EnumColor)positionColor;
                    price = Convert.ToDouble(this.textBoxPrice.Text);
                    date = DateTime.Parse(dateTimePickerDate.Text);
                    suspension = (EnumSuspension)positionSuspension;
                    height = Convert.ToDouble(this.textBoxHeight.Text);

                    MountainBike aMountain = new MountainBike(sn, type, make, speed, color, date, price, suspension, height);
                    mountainList[indexMountain] = aMountain;
                    MessageBox.Show("Mountain Bike Number: " + sn + " has been updated");
                }
                if (radioButtonRoad.Checked)
                {
                    sn = Convert.ToInt64(this.textBoxSN.Text);
                    type = EnumBikesType.Road_Bikes;
                    make = this.textBoxMake.Text;
                    speed = Convert.ToDouble(this.textBoxSpeed.Text);
                    color = (EnumColor)positionColor;
                    price = Convert.ToDouble(this.textBoxPrice.Text);
                    date = DateTime.Parse(dateTimePickerDate.Text);
                    seatHeight = Convert.ToDouble(this.textBoxSeatHeight.Text);
                    wheelSize = Convert.ToDouble(this.textBoxWheelSize.Text);

                    RoadBike aRoad = new RoadBike(sn, type, make, speed, color, date, price, seatHeight, wheelSize);
                    roadList[indexRoad] = aRoad;
                    MessageBox.Show("Road Bike Number: " + sn + " has been updated");
                }
                else if (!radioButtonMountain.Checked && !radioButtonRoad.Checked)
                    MessageBox.Show("The list is empty ....");
            }
            else MessageBox.Show("The list has NOT Changed ....");
        }

        //****** Search ******//
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Bike bikeFound = null;
            bool found = false;

            bool correct = false;
            string input = textBoxSearch.Text;
            
            do
            {
                if (RegExValidator.IsEmpty(input))
                {
                    correct = true;
                    continue;
                }
                if (!correct) MessageBox.Show("Enter a valid number!",
                                                "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            } while (!correct);

            foreach (Bike record in listOfBikes)
            {
                if (record.SerialNumber == Convert.ToInt64(this.textBoxSearch.Text))
                {
                    bikeFound = record;
                    found = true;
                    textBoxSearch.Text = "";
                    textBoxSearch.Focus();
                    break;
                }
            }
            if (found) MessageBox.Show("Bike found... \n" + bikeFound);
            else MessageBox.Show("Bike is not found... ");
        }
    }
}
