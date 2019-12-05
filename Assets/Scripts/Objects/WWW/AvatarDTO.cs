using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects.WWW
{
    public struct AvatarDto
    {
        public Guid Guid { get; set; }
        public int Ordem { get; set; }
        public AvatarLocalization NomesLocalizados { get; set; }
        public Elements Elementos { get; set; }
        public ContainerImages ContainerElementos { get; set; }
    }

    public struct AvatarLocalization
    {
        public int LocalizacaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public struct Elements
    {
        public Guid Guid { get; set; }
        public string ImagemAplicadaGuid { get; set; }
        public string ImagemMiniaturaGuid { get; set; }
    }

    public struct ContainerImages
    {
        public string Url { get; set; }
        public string Container { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}