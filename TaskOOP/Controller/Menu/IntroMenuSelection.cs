using Game.View.Implementation;
using Game.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Controller.Menu
{
    class IntroMenuSelection : InputMenu
    {
        private readonly SubMenuIntro intro;
        private readonly IGameIntroView giv;
        public IntroMenuSelection()
        {
            intro = new SubMenuIntro(this);
            Add(intro);
            giv = new GameIntroViewImpl();
        }
        public IntroMenuSelection(SubMenuIntro intro, GameIntroViewImpl giv)
        {
            this.intro = intro;
            Add(intro);
            this.giv = giv;
        }
        public override void Input(ISet<Command> commands)
        {
            base.Input(commands);
            (GetFather() as IMenuSelection)?.Select(typeof(MainMenuSelection));
        }
        public override void FatherChanged(IMenuSelection? previous, IMenuSelection? next, object? param = null)
        {
            base.FatherChanged(previous, next, param);
            if (next != null && next.Equals(this))
            {
                intro.SelectChild();
            }
            else
            {
                intro.UnselectChild();
            }
            giv.ChangedFather(next == this);
        }

    }
}
