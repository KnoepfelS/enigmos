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
        private Panel pnlVerre = new Panel(), pnlTable = new Panel(), pnlPartiJuste = new Panel();
        private Button btnStart = new Button();
        private Timer tJeu = new Timer();
        private int iTemp = 0, iVitesse = 1;
        private bool bStop = false;
        /// <summary>
        /// Cette méthode crée et donne une taille et la localisation du bouton btnStart.
        /// Elle crée et donne une taille, image et la localisation aux panels du verres, de la table et de la partie juste.
        /// Elle crée et donne un texte et la localisation au label de la partie juste.
        /// Elle donne un interval au timer.
        /// </summary>
        public ReflexeEnigmaPanel()
        {
            // Crée le bouton start et donne la taille, l'image, la localisation.___________________
            Controls.Add(btnStart);

            btnStart.Width = 150;
            btnStart.Height = 40;
            btnStart.Location = new Point(650, 560);
            btnStart.Text = "Commencer";
            btnStart.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            btnStart.FlatStyle = FlatStyle.System;
            btnStart.Click += new EventHandler(Start);
            //Fin de la création du bouton._________________________________________________________

            // Crée le panel du verre et donne la taille, l'image, la localisation._________________
            Controls.Add(pnlVerre);
            pnlVerre.Width = 60;
            pnlVerre.Height = 60;
            pnlVerre.BackgroundImage = Properties.Resources.Verre;
            pnlVerre.Left = 370;
            //Fin de la création du panel.__________________________________________________________

            // Crée le panel de la table et donne la taille, l'image, la localisation.______________
            Controls.Add(pnlTable);
            pnlTable.Width = 300;
            pnlTable.Height = 60;
            pnlTable.BackgroundImage = Properties.Resources.Table;
            pnlTable.Location = new Point(250, 540);
            //Fin de la création du panel.__________________________________________________________

            // Crée le panel de la partie juste et donne la taille, l'image, la localisation._______
            Controls.Add(pnlPartiJuste);
            pnlPartiJuste.Width = 20;
            pnlPartiJuste.Height = 25;
            pnlPartiJuste.BackgroundImage = Properties.Resources.PartiJuste;
            pnlPartiJuste.Location = new Point(350, 515);
            //Fin de la création du panel.__________________________________________________________

            // Crée le label de la partie juste et donne le texte, l'image, la localisation.________
            Controls.Add(lblPartiJuste);
            lblPartiJuste.Text = "Partie juste";
            lblPartiJuste.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblPartiJuste.ForeColor = Color.Green;
            lblPartiJuste.Location = new Point(250, 515);
            //Fin de la création du label.__________________________________________________________

            tJeu.Interval = 1; //Donne l'interval au timer
            tJeu.Tick += new EventHandler(timer_tJeu); //Appel la méthode "timer_tjeu" a chaque tic.

        }
        /// <summary>
        /// Cette méthode permet de lancer le jeu.
        /// Quand la méthode est rappeler sa stoppe le verre qui tombe et verifie s'il c'est arreté dans la partie juste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start(object sender, EventArgs e)
        {
            if (bStop == false) //Lance le timer et change le texte du bouton
            {
                tJeu.Start();
                btnStart.Text = "Stop";
                bStop = true;
            }
            else //Stop le timer, réinitialise la vitesse et vérifie si le verre c'est arreté au bonne endroit.
            {
                tJeu.Stop();
                iVitesse = 1;
                if(pnlVerre.Bottom <= pnlTable.Top && pnlVerre.Bottom >= pnlTable.Top - 25) //Affiche une messagebox pour dire qu'il a réussi, donne la bonne réponse.
                {
                    //Affiche une MessageBox, renvoie le verre à sa place d'origine et change le texte du bouton.
                    MessageBox.Show("Bravo, vous avez réussi voici la reponse. \n \n Bon réflexe", "Bravo");
                    bStop = false;
                    btnStart.Text = "Commencer";
                    pnlVerre.Location = new Point(370, 0);
                }
                else //Affiche une messagebox pour dire qu'il a perdu et qu'il doit recommencer. 
                {
                    //Affiche une MessageBox, renvoie le verre à sa place d'origine et change le texte du bouton.
                    MessageBox.Show("Dommage, vous n'avez pas cliquez au bon moment", "Dommage"); //Quand le joueur perd.
                    bStop = false;
                    btnStart.Text = "Commencer";
                    pnlVerre.Location = new Point(370, 0);
                }
            }
        }
        
        /// <summary>
        /// Cette méthode permet de faire tomber le verre et augmente ça vitesse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_tJeu(object sender, EventArgs e)
        {
            if(iTemp%10 == 0) //Augmente la vitesse.
            {
                iVitesse+=1;
            }
            if (iTemp % 15 == 0) //Augmente la vitesse.
            {
                iVitesse += 2;
            }
            pnlVerre.Top += iVitesse; //Fait tomber le verre
            iTemp++;
        }
    }
}
