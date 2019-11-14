using Game.View.Implementation;
using Game.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Controller.Menu
{
    /// <summary>
    /// Menu selection for the intro of the game
    /// </summary>
    class IntroMenuSelection : InputMenu
    {
        private readonly SubMenuIntro intro;
        private readonly IGameIntroView giv;
        /// <summary>
        /// Initialize with the default sub menu.
        /// </summary>
        public IntroMenuSelection()
        {
            intro = new SubMenuIntro(this);
            Add(intro);
            giv = new GameIntroViewImpl();
        }
        /// <summary>
        /// Initialize with a custom sub menu and a view member
        /// </summary>
        /// <param name="intro">The sub menu for the intro</param>
        /// <param name="giv">The view member used for visual effect.</param>
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
