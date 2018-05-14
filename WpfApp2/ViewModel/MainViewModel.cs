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
                    new CommandViewModel(CommandOne,"测试菜单一","atm.png","for test"),
                    new CommandViewModel(CommandTwo,"流文档测试","atm.png","流文档各类操作测试")
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
                    new CommandViewModel(CommandOne,"测试子菜单一","atm.png","for test"),
                    new CommandViewModel(CommandOne,"测试子菜单二","attach.png","for test"),
                    new CommandViewModel(CommandOne,"测试子菜单三","baloon.png","for test")
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
            saveFileDialog.Filter = "Excel 2003文件|*.xls|Excel 2007文件|.xlsx";
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                if (fileName.Contains("xlsx"))
                {
                    //生成xlsx文件
                    XSSFWorkbook workbook07 = new XSSFWorkbook();
                    workbook07.CreateSheet("测试工作表1");
                    XSSFSheet sheet1 = (XSSFSheet)workbook07.GetSheet("测试工作表1");
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
                    //生成xls文件
                    HSSFWorkbook workbook03 = new HSSFWorkbook();
                    workbook03.CreateSheet("sheet1");
                    workbook03.CreateSheet("sheet2");
                    workbook03.CreateSheet("测试工作表3");
                    using (FileStream fileStream03 = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        workbook03.Write(fileStream03);
                        workbook03.Close();
                    }
                }
                else
                {
                    MessageBox.Show("文件名错误，请检查后重试", "系统提示");
                    return;
                }


                if (File.Exists(fileName))
                {
                    MessageBox.Show("文件保存成功", "系统提示");
                }
                else
                {
                    MessageBox.Show("文件创建失败", "系统提示");
                }
            }


        }
    }


}