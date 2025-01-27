﻿// Copyright © 2022 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-ControlBase

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HeBianGu.Systems.Project
{
    public partial class ProjectListBox : System.Windows.Controls.ListBox
    {
        public static ComponentResourceKey DefaultKey => new ComponentResourceKey(typeof(ProjectListBox), "S.ProjectListBox.Default");

        static ProjectListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProjectListBox), new FrameworkPropertyMetadata(typeof(ProjectListBox)));
        }

        public IEnumerable<IProjectItem> Projects
        {
            get { return (IEnumerable<IProjectItem>)GetValue(ProjectsProperty); }
            set { SetValue(ProjectsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectsProperty =
            DependencyProperty.Register("Projects", typeof(IEnumerable<IProjectItem>), typeof(ProjectListBox), new FrameworkPropertyMetadata(default(IEnumerable<IProjectItem>), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) =>
             {
                 ProjectListBox control = d as ProjectListBox;

                 if (control == null) return;


                 if (e.OldValue is INotifyCollectionChanged o)
                 {
                     o.CollectionChanged -= control.Config_CollectionChanged;
                 }

                 if (e.NewValue is INotifyCollectionChanged n)
                 {
                     n.CollectionChanged -= control.Config_CollectionChanged;
                     n.CollectionChanged += control.Config_CollectionChanged;
                 }


                 control.Refresh();
             }));

        private void Config_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this?.Refresh();
        }

        public IProjectItem SelectedProject
        {
            get { return (ProjectItem)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(IProjectItem), typeof(ProjectListBox), new FrameworkPropertyMetadata(default(IProjectItem), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) =>
             {
                 ProjectListBox control = d as ProjectListBox;

                 if (control == null) return;

                 IProjectItem config = e.NewValue as IProjectItem;

             }));

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            this.SelectedProject = (this.SelectedItem as ProjectItemViewModel)?.Model;
        }


        public Func<IProjectItem, string> GroupBy
        {
            get { return (Func<IProjectItem, string>)GetValue(GroupByProperty); }
            set { SetValue(GroupByProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupByProperty =
            DependencyProperty.Register("GroupBy", typeof(Func<ProjectItem, string>), typeof(ProjectListBox), new FrameworkPropertyMetadata(default(Func<ProjectItem, string>), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) =>
               {
                   ProjectListBox control = d as ProjectListBox;

                   if (control == null) return;

                   Func<IProjectItem, string> config = e.NewValue as Func<IProjectItem, string>;

               }));


        public void Refresh()
        {
            if (this.Projects == null) return;

            IEnumerable<IGrouping<string, IProjectItem>> groups = this.Projects.OrderBy(l => !l.IsFixed).ThenBy(l => l.UpdateTime).GroupBy(this.GroupBy ?? new Func<IProjectItem, string>(l =>
                    {
                        if (l.IsFixed) return "已固定";

                        if (l.UpdateTime.Date == DateTime.Now.Date) return "今天";

                        return "更早";
                    }));

            ObservableCollection<ProjectItemViewModel> models = new ObservableCollection<ProjectItemViewModel>();

            foreach (IGrouping<string, IProjectItem> group in groups)
            {
                foreach (IProjectItem item in group)
                {
                    models.Add(new ProjectItemViewModel(item) { GroupName = group.Key });
                }
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                //Do ：分组
                ICollectionView vw = CollectionViewSource.GetDefaultView(models);
                vw.GroupDescriptions.Clear();
                vw.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));

                //vw.SortDescriptions.Clear(); 
                //vw.SortDescriptions.Add(new SortDescription());
            });

            this.ItemsSource = models;
        }
    }
}
