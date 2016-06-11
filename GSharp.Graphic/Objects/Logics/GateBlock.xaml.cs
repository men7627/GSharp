﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GSharp.Graphic.Blocks;
using GSharp.Graphic.Holes;
using GSharp.Base.Cores;
using GSharp.Base.Statements;
using GSharp.Base.Objects;
using GSharp.Extension;
using GSharp.Base.Objects.Logics;

namespace GSharp.Graphic.Objects.Logics
{
    /// <summary>
    /// GateBlock.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GateBlock : LogicBlock
    {
        // Hole List
        public override List<BaseHole> HoleList
        {
            get
            {
                return _HoleList;
            }
        }
        private List<BaseHole> _HoleList;

        // Gate Object
        public GGate GGate
        {
            get
            {
                GObject logic1 = LogicHole1.LogicBlock?.GObject;
                GObject logic2 = LogicHole2.LogicBlock?.GObject;

                GGate.GateType op = GetGateType();

                return new GGate(logic1, op, logic2);
            }
        }

        // Logic Object
        public override GLogic GLogic
        {
            get
            {
                return GGate;
            }
        }

        // Object List
        public override List<GBase> ToGObjectList()
        {
            return new List<GBase>() { GLogic };
        }

        public GateBlock()
        {
            InitializeComponent();

            _HoleList = new List<BaseHole>
            {
                LogicHole1,
                LogicHole2
            };

            InitializeBlock();
        }

        public GGate.GateType GetGateType()
        {
            if (Operator.SelectedIndex == 0)
            {
                return GGate.GateType.AND;
            }
            else
            {
                return  GGate.GateType.OR;
            }
        }
    }
}
