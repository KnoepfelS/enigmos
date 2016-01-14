using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class TirArcEnigmaPanel : EnigmaPanel
    {
        private Panel pnlCible = new Panel();
        private Panel pnlChoixVertical = new Panel();
        private Panel pnlChoixHorizontal = new Panel();
        private Timer tJeu;
        int iCompteur;
        public TirArcEnigmaPanel()
        {
            Controls.Add(pnlCible);
            pnlCible.Width = 200;
            pnlCible.Height = 200;
            pnlCible.BackgroundImage = Properties.Resources.Cible;
            pnlCible.Left = 300;
            pnlCible.Top = 225;

            Controls.Add(pnlChoixVertical);
            pnlChoixVertical.Width = 20;
            pnlChoixVertical.Height = 3;
            pnlChoixVertical.BackColor = Color.DarkRed;
            pnlChoixVertical.Left = 280;
            pnlChoixVertical.Top = 325;

            Controls.Add(pnlChoixHorizontal);
            pnlChoixHorizontal.Width = 3;
            pnlChoixHorizontal.Height = 20;
            pnlChoixHorizontal.BackColor = Color.DarkRed;
            pnlChoixHorizontal.Left = 400;
            pnlChoixHorizontal.Top = 205;

            //tJeu.Interval = 1; //Donne l'interval au timer
            //tJeu.Tick += new EventHandler(timer_tJeu); //Appel la méthode "timer_tjeu" a chaque tic.
        }

       /* private void timer_tJeu(object sender, EventArgs e)
        {
            
        }*/
    }
}
