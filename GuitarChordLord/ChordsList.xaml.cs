﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight;
using GuitarChordLord.Mvvm;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GuitarChordLord
{
    public sealed partial class ChordsList : Page
    {
        public ChordsList()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var refreshable = DataContext as IRefreshable;
            if(refreshable != null)
                refreshable.Refresh();
        }
    }
}
