using System;
using System.Collections.Generic;
using System.Text;
using Game.View.Implementation;
using Game.View.Interfaces;

namespace Game.Controller.Menu
{
    internal class SubMenuIntro : SubMenu
    {
        private readonly ISubMenuIntroView smv;
        public SubMenuIntro(IMenuSelection selection) : base(selection)
        {
            smv = new SubMenuIntroViewImpl();
        }
        public SubMenuIntro(IMenuSelection selection, SubMenuIntroViewImpl smv) : base(selection)
        {
            this.smv = smv;
        }
        public override void SelectChild()
        {
            base.SelectChild();
            smv.Play();
        }

        public override ISubMenuView GetSubMenuView()
        {
            return smv;
        }

        public override void UnselectChild()
        {
            smv.Clean();
        }
    }
}
