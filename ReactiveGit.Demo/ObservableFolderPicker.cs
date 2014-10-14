﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveGit.Demo
{
    public class ObservableFolderPicker
    {
        public static IObservable<string> SelectFolder()
        {
            return Observable.Defer(() =>
            {
                var fileDialog = new FolderBrowserDialog
                {
                    RootFolder = Environment.SpecialFolder.MyDocuments,
                    ShowNewFolderButton = true
                };

                var result = fileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return Observable.Return(fileDialog.SelectedPath);
                }

                return Observable.Throw<string>(new InvalidOperationException());
            });


        }
    }
}
