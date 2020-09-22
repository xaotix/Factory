using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace DLMCam
{
    public class Perfil
    {
        #region Propriedades Internas
        private double _Diametro { get; set; } = 0;
        private double _EspMesa { get; set; } = 0;
        private string _Descricao { get; set; } = "";
        private double _Peso_Metro { get; set; } = 0;
        private double _EspInf { get; set; } = 0;
        private double _Raio { get; set; } = 0;
        private double _RaioContorno_1 { get; set; } = 0;
        private double _RaioContorno_2 { get; set; } = 0;
        private double _AbaS { get; set; } = 0;
        private double _AbaI { get; set; } = 0;
        private double _Espessura { get; set; } = 0;
        private double _Altura { get; set; } = 0;
        private double _Aba { get; set; } = 0;
        private double _Largura { get; set; } = 0;
        private double _EspAlma { get; set; } = 0;
        private double _LargSup { get; set; } = 0;
        private double _LargInf { get; set; } = 0;
        private double _EspSup { get; set; } = 0;
        #endregion
        public override string ToString()
        {
            return $"{this.Descricao}";
        }
        public TipoPerfil Tipo { get; set; } = TipoPerfil.Chapa;
        public Familia Familia
        {
            get
            {
                return DLMCamFuncoes.GetFamilia(this.Tipo);
            }
        }

        /*Propriedades Primitivas*/
        public double Comprimento { get; set; } = 1000;
        public double Altura
        {
            get
            {
                if (Tipo == TipoPerfil.Barra_Redonda | this.Tipo == TipoPerfil.Tubo_Redondo)
                {
                    return this.Diametro;
                }
                return this._Altura;
            }
            set
            {
                this._Altura = value;
            }
        }
        public double Largura
        {
            get
            {
                if (Tipo == TipoPerfil.Barra_Redonda | this.Tipo == TipoPerfil.Tubo_Redondo)
                {
                    return this.Diametro;
                }
                else if (this._Largura == 0 &&
                    (
                    this.Tipo == TipoPerfil.Tubo_Quadrado |
                    this.Tipo == TipoPerfil.Tubo_Redondo |
                    this.Tipo == TipoPerfil.Barra_Redonda
                    )
                    )
                {
                    return this.Altura;
                }
                if (this._Largura == 0)
                {
                    return this._LargInf > this._LargSup ? this._LargInf : this._LargSup;
                }
                return this._Largura;
            }
            set
            {
                this._Largura = value;
            }
        }
        public double Espessura
        {
            get
            {
                if (this._Espessura == 0 && this._Diametro > 0 && this.Tipo == TipoPerfil.Barra_Redonda)
                {
                    return this._Diametro;
                }


            
                if(this._Espessura==0)
                {
                    List<double> esps = new List<double>();
                    esps.Add(_EspAlma);
                    esps.Add(_EspInf);
                    esps.Add(_EspSup);

                    return esps.Max();
                }

                return this._Espessura;
            }
            set
            {
                this._Espessura = value;
            }
        }
        public double Aba
        {
            get
            {
                if (_Aba == 0)
                {
                    return _AbaI > _AbaS ? _AbaI : _AbaS;
                }
                return _Aba;
            }
            set
            {
                _Aba = value;
            }
        }
        public double AbaS
        {
            get
            {
                if (_AbaS > 0)
                {
                    return _AbaS;
                }
                return Aba;
            }
            set
            {
                _AbaS = value;
            }

        }
        public double AbaI
        {
            get
            {
                if (_AbaI > 0)
                {
                    return _AbaI;
                }
                return Aba;
            }
            set
            {
                _AbaI = value;
            }
        }
        public double Diametro
        {
            get
            {

                if (_Diametro > 0)
                {
                    return _Diametro;
                }
                if (this.Tipo == TipoPerfil.Barra_Redonda)
                {
                    return Espessura;
                }
                return 0;
            }
            set
            {
                _Diametro = value;
            }
        }
        public double EntreAlmas { get; set; } = 100;
        public double Angulo { get; set; } = 135;
        
        
        public double LargS
        {
            get
            {
                if (_LargInf > 0)
                {
                    return _LargInf;
                }
                return _Largura;
            }
            set
            {
                _LargInf = value;
            }
        }
        public double LargI
        {
            get
            {
                if (_LargSup > 0)
                {
                    return _LargSup;
                }
                return _Largura;
            }
            set
            {
                _LargSup = value;
            }
        }
        public double LarguraCartola
        {
            get
            {
                if(this.Tipo == TipoPerfil.Cartola)
                {
                return this.Aba * 2 + this.Largura - (this.Espessura * 2);
                }
                return 0;
            }
        }
        public double EspMesa
        {
            get
            {
                if (_EspMesa > 0)
                {
                    return _EspMesa;
                }
                if(_EspInf>0 | _EspSup>0)
                {
                    return _EspInf > _EspSup ? _EspInf : _EspSup;
                }
                return Espessura;
            }
            set
            {
                _EspMesa = value;
            }
        }
        public double EspAlma
        {
            get
            {
                if(_EspAlma>0)
                {
                    return _EspAlma;
                }
                return Espessura;
            }
            set
            {
                _EspAlma = value;
            }
        }
        public double EspI
        {
            get
            {
                if (_EspSup > 0)
                {
                    return _EspSup;
                }
                return EspMesa;
            }
            set
            {
                _EspSup = value;
            }
        }
        public double EspS
        {
            get
            {
                if (_EspInf > 0)
                {
                    return _EspInf;
                }
                return EspMesa;
            }
            set
            {
                _EspInf = value;
            }
        }
        public double EspLIV1
        {
            get
            {
                switch (this.Familia)
                {
                    case Familia.Soldado:
                        return this.EspAlma;
                    case Familia.Laminado:
                        return this.EspAlma;
                }
                return this.Espessura;
            }
        }
        public double EspLIV2
        {
            get
            {
                switch (this.Familia)
                {
                    case Familia.Soldado:
                        return this.EspS;
                    case Familia.Laminado:
                        return this.EspS;
                }
                return this.Espessura;
            }
        }
        public double EspLIV3
        {
            get
            {
                switch (this.Familia)
                {
                    case Familia.Soldado:
                        return this.EspI;
                    case Familia.Laminado:
                        return this.EspI;
                }
                return this.Espessura;
            }
        }
        public double EspLIV4
        {
            get
            {
                switch (this.Familia)
                {
                    case Familia.Soldado:
                        return this.EspAlma;
                    case Familia.Laminado:
                        return this.EspAlma;
                }
                return this.Espessura;
            }
        }
        public double AlturaAlma
        {
            get
            {
                if (this.Dobras == 1 | this.Tipo == TipoPerfil.T_Soldado)
                {
                    return Math.Round(this.Altura - this.EspMesa,DLMCamVars.Decimais.Corte);
                }
                else if(
                      this.Tipo == TipoPerfil.Caixao 
                    | this.Tipo == TipoPerfil.I_Soldado 
                    | this.Tipo == TipoPerfil.Tubo_Quadrado 
                    | this.Tipo == TipoPerfil.INP 
                    | this.Tipo == TipoPerfil.UNP 
                    | this.Tipo == TipoPerfil.UAP 
                    | this.Tipo == TipoPerfil.C_Enrigecido
                    | this.Tipo == TipoPerfil.U_Dobrado
                    | this.Tipo == TipoPerfil.Z_Dobrado
                    | this.Tipo == TipoPerfil.Z_Purlin
                    )
                {
                    return Math.Round(this.Altura - this.EspS - this.EspI, DLMCamVars.Decimais.Corte);
                }
                else if(this.Tipo == TipoPerfil.L_Laminado)
                {
                    return Math.Round(this.Altura - this.Espessura,DLMCamVars.Decimais.Corte);
                }
                return 0;
            }
        }
        public double Rosca_Inicio { get; set; } = 0;
        public double Rosca_Fim { get; set; } = 0;
        public string Descricao
        {
            get
            {
                if(_Descricao!="")
                {
                    return _Descricao;
                }
                return GetDescricao();
            }
            set
            {
                _Descricao = value;
            }
        }
        public double Peso_Metro_MS
        {
            get
            {
                if(this.Tipo == TipoPerfil.Caixao | this.Tipo ==  TipoPerfil.I_Soldado| this.Tipo == TipoPerfil.T_Soldado | this.Tipo == TipoPerfil.INP | this.Tipo == TipoPerfil.WLam)
                {
                return Math.Round(this.EspI * this.LargI * 1000 * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9)), DLMCamVars.Decimais.Peso);
                }
                else if(this.Tipo == TipoPerfil.L_Laminado)
                {
                    return Math.Round(this.Espessura * this.Largura * 1000 * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9)), DLMCamVars.Decimais.Peso);
                }
                return 0;
            }
        }
        public double Peso_Metro_MI
        {
            get
            {
                if (this.Tipo == TipoPerfil.Caixao | this.Tipo == TipoPerfil.I_Soldado | this.Tipo == TipoPerfil.INP | this.Tipo == TipoPerfil.WLam)
                {
                    return Math.Round(this.EspS * this.LargI * 1000 * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9)), DLMCamVars.Decimais.Peso);
                }
                return 0;
            }
        }
        public double Peso_Metro_Alma
        {
            get
            {
                if (
                      this.Tipo == TipoPerfil.Tubo_Quadrado 
                    | this.Tipo == TipoPerfil.Caixao 
                    | this.Tipo == TipoPerfil.I_Soldado 
                    | this.Tipo == TipoPerfil.T_Soldado 
                    | this.Tipo == TipoPerfil.INP 
                    | this.Tipo == TipoPerfil.WLam 
                    | this.Tipo == TipoPerfil.L_Laminado
                    )
                {
                    var peso = Math.Round(this.EspAlma * this.AlturaAlma * 1000 * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9)), DLMCamVars.Decimais.Peso); 

                    return peso;
                }
                return 0;
            }
        }
        public double Peso_Metro
        {
            get
            {
                if(_Peso_Metro>0)
                {
                    return _Peso_Metro;
                }
                double comp = 1000;
                if (this.Tipo == TipoPerfil.Caixao | this.Tipo == TipoPerfil.Tubo_Quadrado)
                {
                    return Math.Round((this.Peso_Metro_Alma * 2) + this.Peso_Metro_MI + this.Peso_Metro_MS, DLMCamVars.Decimais.Peso);
                }
                else if (this.Tipo == TipoPerfil.I_Soldado | this.Tipo ==  TipoPerfil.WLam | this.Tipo == TipoPerfil.INP)
                {
                    return Math.Round(this.Peso_Metro_Alma + this.Peso_Metro_MI + this.Peso_Metro_MS, DLMCamVars.Decimais.Peso);
                }
                else if (this.Tipo == TipoPerfil.T_Soldado | this.Tipo == TipoPerfil.L_Laminado)
                {
                    return Math.Round(this.Peso_Metro_Alma + this.Peso_Metro_MS, DLMCamVars.Decimais.Peso);
                }
                else if(this.Familia == Familia.Dobrado | this.Familia == Familia.Chapa | this.Tipo == TipoPerfil.Barra_Chata)
                {
                    return Math.Round(comp * this.Corte * this.Espessura * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9)), DLMCamVars.Decimais.Peso);
                }
                else if(this.Tipo == TipoPerfil.Barra_Redonda)
                {
                    return Math.Round(this.Diametro * Math.PI * comp * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9)), DLMCamVars.Decimais.Peso);
                }
                else if(this.Tipo == TipoPerfil.Tubo_Redondo)
                {
                    var ptot =this.Diametro * Math.PI * comp * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9));
                    var p_interno = (this.Diametro - this.Espessura) * Math.PI  * comp * (DLMCamVars.PesoAcoMetroCubico / Math.Pow(10, 9));
                    return Math.Round(ptot - p_interno, DLMCamVars.Decimais.Peso);
                }

                return 0;
            }
        }
        public double PesoSemRecorte
        {
            get
            {
                return Math.Round(this.Peso_Metro / 1000 * this.Comprimento,DLMCamVars.Decimais.Peso);
            }
        }
        public int Dobras
        {
            get
            {
                return DLMCamFuncoes.GetDobras(this.Tipo);
            }
        }
        public double DescontoDobras
        {
            get
            {
                return (2 * Dobras * Espessura);
            }
        }
        public double Corte
        {
            get
            {
                switch (Familia)
                {
                    case Familia.Soldado:
                        return 0;
                    case Familia.Dobrado:
                       if(this.Tipo == TipoPerfil.Cartola)
                        {
                            return Math.Round((2 * Largura) + (AbaS + AbaI) + Altura - DescontoDobras, DLMCamVars.Decimais.Corte);
                        }
                       else if(this.Tipo == TipoPerfil.C_Enrigecido)
                        {
                            return (Math.Round((2 * Largura) + (AbaS + AbaI) + Altura - DescontoDobras, DLMCamVars.Decimais.Corte));
                        }
                       else if(this.Tipo == TipoPerfil.L_Dobrado)
                        {
                            return Math.Round(this.Altura + this.Largura - DescontoDobras, DLMCamVars.Decimais.Corte);
                        }
                       else if(this.Tipo == TipoPerfil.U_Dobrado)
                        {
                            return Math.Round((2 * Largura) + Altura - DescontoDobras, DLMCamVars.Decimais.Corte);
                        }
                       else if(this.Tipo == TipoPerfil.Z_Dobrado)
                        {
                            return Math.Round((2 * Largura) + Altura - DescontoDobras, DLMCamVars.Decimais.Corte);
                        }
                       else if(this.Tipo == TipoPerfil.Z_Purlin)
                        {
                            return Math.Round((2 * Largura) + (AbaS + AbaI) + Altura - DescontoDobras, DLMCamVars.Decimais.Corte);
                        }
                        return 0;
                    case Familia.Especial:
                        return 0;
                    case Familia.Laminado:
                        return 0;
                    case Familia.Chapa:
                        return this.Largura;
                    case Familia._Desconhecido:
                        return 0;
                    case Familia._Erro:
                        return 0;
                }
                return 0;
            }
        }
        public double Raio
        {
            get
            {
                if(this.Tipo == TipoPerfil.Tubo_Redondo | this.Tipo == TipoPerfil.Barra_Redonda)
                {
                    if(this.Diametro>0)
                    {
                        return this.Diametro / 2;
                    }
                }

                return this._Raio;
            }
            set
            {
                this._Raio = value;
            }
        }
        public double RaioContorno_1
        {
            get
            {
                if(_RaioContorno_1>0)
                {
                    return _RaioContorno_1;
                }
                return _Raio;
            }
            set
            {
                _RaioContorno_1 = value;
            }
        }
        public double RaioContorno_2
        {
            get
            {
                if (_RaioContorno_2 > 0)
                {
                    return _RaioContorno_2;
                }
                return _Raio;
            }
            set
            {
                _RaioContorno_2 = value;
            }
        }
        public void SetPesoMetro(double Valor)
        {
            this._Peso_Metro = Valor;
        }
        public string GetDescricao()
        {
            string rt = "";

            switch (this.Tipo)
            {
                /*Falta fazer quando o perfil tem 2 abas diferentes.*/
                case TipoPerfil.Z_Purlin:
                    rt = $"Z1 {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Aba.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.Especial_5:
                    rt = ""; break;
                case TipoPerfil.Especial_6:
                    rt = ""; break;
                case TipoPerfil.Especial_7:
                    rt = ""; break;
                case TipoPerfil.Z_Dobrado:
                    rt = $"Z {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Aba.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.C_Enrigecido:
                    rt = $"C {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Aba.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.L_Dobrado:
                    rt = $"L {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.Cartola:
                    rt = $"CART. {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Aba.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.Tubo_Redondo:
                    rt = $"TUBO DIAM {this.Diametro.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.Tubo_Quadrado:
                    rt = $"TUBO {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.Caixao:
                    rt = "II " + this.Altura + "X";
                    rt = rt + (this.LargI == this.LargS ? this.Largura.ToString("N0") + "X" : this.LargI.ToString("N0") + "X" + this.LargS.ToString("N0") + "X");
                    rt = rt + this.EspAlma.ToString("N2") + "X";
                    rt = rt + (this.EspS == this.EspI ? this.EspS.ToString("N2") : this.EspI.ToString("N2") + "X" + this.EspS.ToString("N2"));
                    rt = rt + " (" + this.EntreAlmas.ToString("N0") + ")";
                    break;
                case TipoPerfil.I_Soldado:
                    rt = "I " + this.Altura + "X";
                    rt = rt + (this.LargI == this.LargS ? this.Largura.ToString("N0") + "X" : this.LargI.ToString("N0") + "X" + this.LargS.ToString("N0") + "X");
                    rt = rt + this.EspAlma.ToString("N2") + "X";
                    rt = rt + (this.EspS == this.EspI ? this.EspS.ToString("N2") : this.EspI.ToString("N2") + "X" + this.EspS.ToString("N2"));
                    break;


                case TipoPerfil.Barra_Chata:
                    rt = $"BARRA {this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.T_Soldado:
                    rt = $"T {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.EspAlma.ToString("N2")}X{this.EspMesa.ToString("N2")}";
                    break;
                case TipoPerfil.Barra_Redonda:
                    return $"BARRA RED {this.Diametro.ToString("N0")}";
                case TipoPerfil.L_Laminado:
                    rt = $"L {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.INP:
                    rt = $"INP {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.EspAlma.ToString("N2")}X{this.EspMesa.ToString("N2")}";
                    break;
                case TipoPerfil.WLam:
                    rt = $"W {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.EspAlma.ToString("N2")}X{this.EspMesa.ToString("N2")}";
                    break;
                case TipoPerfil.UNP:
                    rt = $"UNP {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil._Desconhecido:
                    break;
                case TipoPerfil.Chapa_Xadrez:
                    rt = $"CH. XADREZ {this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.Chapa:
                    rt = $"CH. {this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.U_Dobrado:
                    rt = $"U {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil.UAP:
                    rt = $"UAP {this.Altura.ToString("N0")}X{this.Largura.ToString("N0")}X{this.Espessura.ToString("N2")}";
                    break;
                case TipoPerfil._Erro:
                    break;
            }
            return rt.Replace(",",".");
        }
        public Perfil()
        {

        }
        public Perfil(TipoPerfil tipo, double Comprimento, double Altura, double Largura, double Espessura)
        {
            this.Tipo = tipo;
            this.Comprimento = Comprimento;
            this.Altura = Altura;
            if(tipo == TipoPerfil.Tubo_Redondo)
            {
                this.Diametro = Altura;
                this.Espessura = Espessura;
            }
            this.Largura = Largura;
            this.Espessura = Espessura;

        }
        public Perfil(TipoPerfil tipo, double Comprimento, double Altura, double Largura, double EspessuraAlma, double EspessuraMesa)
        {
            this.Tipo = tipo;
            this.Comprimento = Comprimento;
            this.Altura = Altura;
            if (tipo == TipoPerfil.Tubo_Redondo)
            {
                this.Diametro = Altura;
                this.Espessura = Espessura;
            }
            this.Largura = Largura;
            this.EspAlma = EspessuraAlma;
            this.EspMesa = EspessuraMesa;

            this.Espessura = this.EspAlma > this.EspMesa ? this.EspAlma : this.EspMesa;

        }
        public Perfil(TipoPerfil tipo)
        {
            this.Tipo = tipo;
        }
        public Perfil Criar(double Comprimento, TipoPerfil tipo, double Altura, double Alma, double Largura = 0, double Mesa = 0, double Aba = 0, double Largura2 = 0, double Aba2 = 0, double Espessura2 = 0)
        {
            string Descricao = "";
            switch (tipo)
            {
                case TipoPerfil.Z_Purlin:
                    return new Z_Purlin(Descricao,Altura,Largura,Largura2,Alma,Aba,Aba2,Comprimento);
                case TipoPerfil.Especial_5:
                    return new Chapa(Comprimento, Alma);
                case TipoPerfil.Especial_6:
                    return new Chapa(Comprimento, Alma);
                case TipoPerfil.Especial_7:
                    return new Chapa(Comprimento, Alma);
                case TipoPerfil.Z_Dobrado:
                    return new Z_Dobrado(Descricao, Altura, Largura,Largura2, Alma, Comprimento);
                case TipoPerfil.C_Enrigecido:
                    return new C_Enrigecido(Descricao, Altura, Largura, Alma, Aba, Comprimento);
                case TipoPerfil.L_Dobrado:
                    return new L_Dobrado(Descricao, Altura, Largura, Alma, Comprimento);
                case TipoPerfil.Cartola:
                    return new Cartola(Descricao, Altura, Largura, Alma, Aba, Comprimento);
                case TipoPerfil.Tubo_Redondo:
                    return new Tubo_Redondo(Descricao, Comprimento, Largura, Alma);
                case TipoPerfil.Tubo_Quadrado:
                    return new Tubo_Quadrado(Descricao, Altura, Largura, Alma, Comprimento);
                case TipoPerfil.Caixao:
                    return new Caixao(Comprimento, Altura, Largura,Largura2,Mesa,Espessura2, Alma,100);
                case TipoPerfil.I_Soldado:
                    return new I_Soldado(Comprimento, Altura, Largura,Largura2, Mesa, Espessura2, Alma, Descricao);
                case TipoPerfil.Barra_Chata:
                    return new Barra_Chata(Descricao,Comprimento,Altura, Alma);
                case TipoPerfil.T_Soldado:
                    return new T_Soldado(Comprimento, Largura, Altura, Mesa, Alma, Alma, Descricao);
                case TipoPerfil.Barra_Redonda:
                    return new Barra_Redonda(Descricao, Alma, Comprimento);
                case TipoPerfil.L_Laminado:
                    return new L_Laminado(Comprimento, Largura, Alma, Alma,Descricao);
                case TipoPerfil.INP:
                    return new INP(Comprimento,Largura,Altura,Mesa,Alma,Alma,Descricao);
                case TipoPerfil.WLam:
                    return new Wlam(Comprimento, Largura, Altura, Mesa, Alma, Alma, Descricao);
                case TipoPerfil.UNP:
                    return new UNP(Descricao, Altura, Largura, Alma, Comprimento);
                case TipoPerfil.Chapa_Xadrez:
                    return new Chapa(Comprimento, Alma);
                case TipoPerfil.Chapa:
                    return new Chapa(Comprimento, Alma);
                case TipoPerfil.U_Dobrado:
                    return new U_Dobrado(Altura, Largura, Alma, Comprimento);
                case TipoPerfil.UAP:
                    return new UAP(Descricao,Altura, Largura, Alma, Comprimento);
                case TipoPerfil._Desconhecido:
                    return new Chapa(Comprimento, Alma);
                case TipoPerfil._Erro:
                    return new Chapa(Comprimento, Alma);
                default:
                    return new Chapa(Comprimento, Alma);
            }
        }

    }
}