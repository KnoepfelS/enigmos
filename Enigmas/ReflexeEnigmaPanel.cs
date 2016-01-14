using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class ReflexeEnigmaPanel : EnigmaPanel
    {
        //Instanciation d'objets et déclaration de variable.
        private Label lblPartiJuste = new Label();
        private Panel pnlTonneaux = new Panel(), pnlTable = new Panel(), pnlPartiJuste = new Panel();
        private Button btnStart = new Button();
        private Timer tJeu = new Timer();
        private int iTemp = 0, iVitesse = 1;
        private bool bStop = false;
        /// <summary>
        /// Créer le bouton et donne sa taille, son text et la location.
        /// Créer les panels et leurs donnent une image, une taille et la location,
        /// </summary>
        public ReflexeEnigmaPanel()
        {
            Controls.Add(btnStart);//bouton
            btnStart.Width = 150;
            btnStart.Height = 40;
            btnStart.Location = new Point(650, 560);
            btnStart.Text = "Commencer";
            btnStart.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            btnStart.FlatStyle = FlatStyle.System;
            btnStart.Click += new EventHandler(Start);

            Controls.Add(pnlTonneaux); //Le verre
            pnlTonneaux.Width = 60;
            pnlTonneaux.Height = 60;
            pnlTonneaux.BackgroundImage = Properties.Resources.Verre;
            pnlTonneaux.Left = 370;

            Controls.Add(pnlTable);//La Table
            pnlTable.Width = 300;
            pnlTable.Height = 60;
            pnlTable.BackgroundImage = Properties.Resources.Table;
            pnlTable.Location = new Point(250, 540);

            Controls.Add(pnlPartiJuste); //La parti juste.
            pnlPartiJuste.Width = 20;
            pnlPartiJuste.Height = 25;
            pnlPartiJuste.BackgroundImage = Properties.Resources.PartiJuste;
            pnlPartiJuste.Location = new Point(350, 515);

            Controls.Add(lblPartiJuste);
            lblPartiJuste.Text = "Partie juste";
            lblPartiJuste.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblPartiJuste.ForeColor = Color.Green;
            lblPartiJuste.Location = new Point(250, 515);

            tJeu.Interval = 1;
            tJeu.Tick += new EventHandler(timer_tJeu);

        }
        /// <summary>
        /// Quand le joueur clique sur le bouton le timer se lance et le verre tombe puis le texte du bouton change.
        /// Quand il reclique le timer s'arrête et vérifie si le bas du verre se trouve dans la partie juste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start(object sender, EventArgs e)
        {
            if (bStop == false)
            {
                tJeu.Start();
                btnStart.Text = "Stop";
                bStop = true;
            }
            else
            {
                tJeu.Stop();
                iVitesse = 1;
                if(pnlTonneaux.Bottom <= pnlTable.Top && pnlTonneaux.Bottom >= pnlTable.Top - 25) //Quand le joueur réussi.
                {
                    //Affiche une MessageBox, renvoie le verre à sa place d'origine et change le texte du bouton.
                    MessageBox.Show("Bravo, vous avez réussi voici la reponse. \n \n Bon réflexe", "Bravo");
                    bStop = false;
                    btnStart.Text = "Commencer";
                    pnlTonneaux.Location = new Point(370, 0);
                }
                else
                {
                    //Affiche une MessageBox, renvoie le verre à sa place d'origine et change le texte du bouton.
                    MessageBox.Show("Dommage, vous n'avez pas cliquez au bon moment", "Dommage"); //Quand le joueur perd.
                    bStop = false;
                    btnStart.Text = "Commencer";
                    pnlTonneaux.Location = new Point(370, 0);
                }
            }
        }
        /// <summary>
        /// Tout les 10 ticks le verre accélère de 1 pixel.
        /// Tout les 15 ticks le verre accélère de 2 pixels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_tJeu(object sender, EventArgs e)
        {
            if(iTemp%10 == 0)
            {
                iVitesse+=1;
            }
            if (iTemp % 15 == 0)
            {
                iVitesse += 2;
            }
            pnlTonneaux.Top += iVitesse;
            iTemp++;
        }
    }
}
