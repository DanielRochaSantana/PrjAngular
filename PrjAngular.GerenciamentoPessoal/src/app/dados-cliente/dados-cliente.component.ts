import { Component } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../interfaces/Cliente.interface';

@Component({

  selector: 'app-dados-cliente',

  templateUrl: './dados-cliente.component.html'

})

export class DadosClientes {

  public clientes: Cliente[];

  public _UrlBase: string;

  public _ClienteService: ClienteService;

  public cliente = {

    id: '',

    nome: '',

    celular: '',

    ativo: '',

    diretorioDocumentos: ''

  };

  public clienteObtido = {

    id: '',

    nome: '',

    celular: '',

    ativo: '',

    diretorioDocumentos: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(ClienteService: ClienteService) {

    debugger

    this._UrlBase = "https://192.168.15.7:8082/api/Administracao/";

    this._ClienteService = ClienteService;

    this.clientes = []

  }

  public ObterRegistrosAtualizados(): void {

    this._ClienteService.getAll().subscribe(

      resultado => {

        debugger

        this.clientes = resultado;

      },

      erro => {

        debugger

        console.error(erro);

      }

    );

  }

  public salvar(): void {

    debugger

    const data = {

      id: 0,

      nome: this.cliente.nome,

      celular: this.cliente.celular,

      ativo: this.cliente.ativo,

      diretorioDocumentos: this.cliente.diretorioDocumentos

    };

    debugger

    if (!this.editar) {

      debugger

      this._ClienteService.create(data).subscribe(

        resultado => {

          debugger

          console.log(resultado);

          this.submited = true;

          this.ObterRegistrosAtualizados();

        },

        error => {

          debugger

          console.log(error);

        });
    }

    if (this.editar) {

      debugger

      this._ClienteService.update(this.idParaEdicao, data).subscribe(

        resultado => {

          debugger

          console.log(resultado);

          this.submited = true;

          this.ObterRegistrosAtualizados();

        },

        error => {

          debugger

          console.log(error);

        });

      this.editar = false;
    }

  }

  public adicionarCliente(): void {

    debugger

    this.editar = false;

    this.submited = false;

    this.cliente = {

      id: '',

      nome: '',

      celular: '',

      ativo: '',

      diretorioDocumentos: ''

    };

  }

  public listarRegistros(): void {

    debugger

    this.ObterRegistrosAtualizados();

    this.listar = true;

  }

  public editarItem(Id: Number): void {

    debugger

    this.submited = false;

    this.cliente = {

      id: '',

      nome: '',

      celular: '',

      ativo: '',

      diretorioDocumentos: ''

    };

    debugger

    this.obterCliente(Id);

    var cliente = this.clienteObtido;

    debugger

    this.editar = true;

  }

  public obterCliente(Id: Number): void {

    this._ClienteService.get(Id).subscribe(

      resultado => {

        debugger

        this.clienteObtido.id = resultado.id.toString();
        this.clienteObtido.nome = resultado.nome;
        this.clienteObtido.celular = resultado.celular;
        this.clienteObtido.ativo = resultado.ativo ? "true" : "false";
        this.clienteObtido.diretorioDocumentos = resultado.diretorioDocumentos;

        this.preencherCampos();

      },

      erro => {

        debugger

        console.error(erro);

      }

    );

  }

  public limparListagem(): void {

    debugger

    this.listar = false;

  }

  public preencherCampos(): void {

    debugger

    this.cliente.nome = this.clienteObtido.nome;
    this.cliente.celular = this.clienteObtido.celular;
    this.cliente.ativo = this.clienteObtido.ativo;
    this.cliente.diretorioDocumentos = this.clienteObtido.diretorioDocumentos;
    this.idParaEdicao = this.clienteObtido.id;

    debugger

  }

  public removerItem(Id: Number): void {

    debugger

    this.submited = false;

    this.cliente = {

      id: '',

      nome: '',

      celular: '',

      ativo: '',

      diretorioDocumentos: ''

    };

    debugger

    this._ClienteService.delete(Id).subscribe(

      resultado => {

        debugger

        console.log(resultado);

        this.ObterRegistrosAtualizados();

      },

      error => {

        debugger

        console.log(error);

      });

  }
}
