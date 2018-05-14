using GalaSoft.MvvmLight;
using WpfApp2.Model;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System;

namespace WpfApp2.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private MainModel mainModel;

        public MainModel MainModel
        {
            get { return mainModel; }
            set { mainModel = value; RaisePropertyChanged(() => MainModel); }
        }
        public MainViewModel()
        {
            MainModel = new MainModel() { Introduction = "hello world" };
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        public ReadOnlyCollection<CommandViewModel> ShortCutCommand
        {
            get
            {
                List<CommandViewModel> commands = new List<CommandViewModel>()
                {
                    new CommandViewModel(CommandOne,"���Բ˵�һ","atm.png","for test"),
                    new CommandViewModel(CommandTwo,"���ĵ�����","atm.png","���ĵ������������")
                };
                return new ReadOnlyCollection<CommandViewModel>(commands);
            }
        }
        public ReadOnlyCollection<CommandViewModel> ShortCutCommands
        {
            get
            {
                List<CommandViewModel> commands = new List<CommandViewModel>()
                {
                    new CommandViewModel(CommandOne,"�����Ӳ˵�һ","atm.png","for test"),
                    new CommandViewModel(CommandOne,"�����Ӳ˵���","attach.png","for test"),
                    new CommandViewModel(CommandOne,"�����Ӳ˵���","baloon.png","for test")
                };
                return new ReadOnlyCollection<CommandViewModel>(commands);
            }
        }
        public RelayCommand CommandOne
        {
            get
            {
                return new RelayCommand(ExecuteCommand);
            }
        }

        public RelayCommand CommandTwo
        {
            get
            {
                return new RelayCommand(() => ExecuteCommandTwo());
            }
        }

        private void ExecuteCommandTwo()
        {
            new FrmFlowDocument().Show();
        }

        public void ExecuteCommand()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel 2003�ļ�|*.xls|Excel 2007�ļ�|.xlsx";
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                if (fileName.Contains("xlsx"))
                {
                    //����xlsx�ļ�
                    XSSFWorkbook workbook07 = new XSSFWorkbook();
                    workbook07.CreateSheet("���Թ�����1");
                    XSSFSheet sheet1 = (XSSFSheet)workbook07.GetSheet("���Թ�����1");
                    for (int i = 0; i < 10; i++)
                    {
                        sheet1.CreateRow(i);
                        XSSFRow row = (XSSFRow)sheet1.GetRow(i);
                        XSSFCell[] cell = new XSSFCell[10];
                        for (int j = 0; j < 10; j++)
                        {
                            row.CreateCell(j);
                            cell[j] = (XSSFCell)row.GetCell(j);
                            cell[j].SetCellValue((i * 10 + j).ToString());
                        }
                    }

                    using (FileStream fileStream07 = new FileStream(fileName, FileMode.Create))
                    {
                        workbook07.Write(fileStream07);
                        workbook07.Close();
                    }
                }
                else if (fileName.Contains("xls"))
                {
                    //����xls�ļ�
                    HSSFWorkbook workbook03 = new HSSFWorkbook();
                    workbook03.CreateSheet("sheet1");
                    workbook03.CreateSheet("sheet2");
                    workbook03.CreateSheet("���Թ�����3");
                    using (FileStream fileStream03 = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        workbook03.Write(fileStream03);
                        workbook03.Close();
                    }
                }
                else
                {
                    MessageBox.Show("�ļ����������������", "ϵͳ��ʾ");
                    return;
                }


                if (File.Exists(fileName))
                {
                    MessageBox.Show("�ļ�����ɹ�", "ϵͳ��ʾ");
                }
                else
                {
                    MessageBox.Show("�ļ�����ʧ��", "ϵͳ��ʾ");
                }
            }


        }
    }


}