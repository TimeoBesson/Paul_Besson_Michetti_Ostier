using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul_Besson_Michetti_Ostier.Classes
{
    public enum Allergene
    {
      
    }
    public enum CategorieRecette
    {

    }
    public class Recette
    {
        private int idRecette;
        private string nomRecette;
        private string descriptionRecette;
        private List<Allergene> allergenes;
        private CategorieRecette categorieRecette;

        public Recette(int idRecette, string nomRecette, string descriptionRecette, List<Allergene> allergenes, CategorieRecette categorieRecette)
        {
            this.IdRecette = idRecette;
            this.NomRecette = nomRecette;
            this.DescriptionRecette = descriptionRecette;
            this.Allergenes = allergenes;
            this.CategorieRecette = categorieRecette;
        }

        public int IdRecette
        {
            get
            {
                return this.idRecette;
            }

            set
            {
                this.idRecette = value;
            }
        }

        public string NomRecette
        {
            get
            {
                return this.nomRecette;
            }

            set
            {
                this.nomRecette = value;
            }
        }

        public string DescriptionRecette
        {
            get
            {
                return this.descriptionRecette;
            }

            set
            {
                this.descriptionRecette = value;
            }
        }

        public List<Allergene> Allergenes
        {
            get
            {
                return this.allergenes;
            }

            set
            {
                this.allergenes = value;
            }
        }

        public CategorieRecette CategorieRecette
        {
            get
            {
                return this.categorieRecette;
            }

            set
            {
                this.categorieRecette = value;
            }
        }
    }
}
