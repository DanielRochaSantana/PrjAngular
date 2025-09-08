import { Component } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../interfaces/Usuario.interface';

@Component({

  selector: 'app-dados-usuario',

  templateUrl: './dados-usuario.component.html'

})

export class DadosUsuarios {

  public usuarios: Usuario[];

  public _UrlBase: string;

  public _UsuarioService: UsuarioService;

  public usuario = {

    id: '',

    isEdit: false,

    nome: '',

    email: '',

    celular: ''

  };

  public usuarioObtido = {

    id: '',

    isEdit: false,

    nome: '',

    email: '',

    celular: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(UsuarioService: UsuarioService) {

    // debugger

    this._UrlBase = "http://localhost:5275/api/Usuario/";

    this._UsuarioService = UsuarioService;

    this.usuarios = []

  }

  public ObterRegistrosAtualizados(): void {

    this._UsuarioService.getAll().subscribe(

      resultado => {

        // debugger

        this.usuarios = resultado;

      },

      erro => {

        // debugger

        console.error(erro);

      }

    );

  }

  public salvar(): void {

    // debugger

    const data = {

      id: '',

      isEdit: false,

      nome: this.usuario.nome,

      email: this.usuario.email,

      celular: this.usuario.celular,

    };

    // debugger

    if (!this.editar) {

      // debugger

      this._UsuarioService.create(data).subscribe(

        resultado => {

          // debugger

          console.log(resultado);

          this.submited = true;

          this.ObterRegistrosAtualizados();

        },

        error => {

          // debugger

          console.log(error);

        });
    }

    if (this.editar) {

      // debugger

      data.isEdit = true;

      this._UsuarioService.update(this.idParaEdicao, data).subscribe(

        resultado => {

          // debugger

          console.log(resultado);

          this.submited = true;

          this.ObterRegistrosAtualizados();

        },

        error => {

          // debugger

          console.log(error);

        });

      this.editar = false;
    }

  }

  public adicionarUsuario(): void {

    // debugger

    this.editar = false;

    this.submited = false;

    this.usuario = {

      id: '',

      isEdit: false,

      nome: '',

      email: '',

      celular: ''

    };

  }

  public listarRegistros(): void {

    // debugger

    this.ObterRegistrosAtualizados();

    this.listar = true;

  }

  public editarItem(Id: string): void {

    // debugger

    this.submited = false;

    this.usuario = {

      id: '',

      isEdit: false,

      nome: '',

      email: '',

      celular: ''

    };

    // debugger

    this.obterUsuario(Id);

    var usuario = this.usuarioObtido;

    // debugger

    this.editar = true;

  }

  public obterUsuario(Id: string): void {

    this._UsuarioService.get(Id).subscribe(

      resultado => {

        // debugger

        this.usuarioObtido.id = resultado.id.toString();
        this.usuarioObtido.nome = resultado.nome;
        this.usuarioObtido.email = resultado.email;
        this.usuarioObtido.celular = resultado.celular;
        this.usuarioObtido.isEdit = true;

        this.preencherCampos();

      },

      erro => {

        // debugger

        console.error(erro);

      }

    );

  }

  public limparListagem(): void {

    // debugger

    this.listar = false;

  }

  public preencherCampos(): void {

    // debugger

    this.usuario.nome = this.usuarioObtido.nome;
    this.usuario.email = this.usuarioObtido.email;
    this.usuario.celular = this.usuarioObtido.celular;
    this.idParaEdicao = this.usuarioObtido.id;

    // debugger

  }

  public removerItem(Id: string): void {

    // debugger

    this.submited = false;

    this.usuario = {

      id: '',

      isEdit: false,

      nome: '',

      email: '',

      celular: ''

    };

    // debugger

    this._UsuarioService.delete(Id).subscribe(

      resultado => {

        // debugger

        console.log(resultado);

        this.ObterRegistrosAtualizados();

      },

      error => {

        // debugger

        console.log(error);

      });

  }
}
