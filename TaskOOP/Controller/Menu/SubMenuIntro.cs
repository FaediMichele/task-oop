using System;
using System.Collections.Generic;
using System.Text;
using Controller.View.Implementation;
using Controller.View.Interfaces;

namespace Controller.Menu
{
    internal class SubMenuIntro : SubMenu
    {
        private readonly ISubMenuIntroView smv;
        public SubMenuIntro(IMenuSelection selection) : base(selection)
        {
            smv = new SubMenuIntroViewImpl();
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
