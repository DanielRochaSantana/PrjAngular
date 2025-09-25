import { Component } from '@angular/core';
import { AtuacaoService } from '../services/atuacao.service';
import { Atuacao } from '../interfaces/Atuacao.interface';

@Component({

  selector: 'app-dados-atuacao',

  templateUrl: './dados-atuacao.component.html'

})

export class DadosAtuacoes {

  public atuacoes: Atuacao[];

  public _UrlBase: string;

  public _AtuacaoService: AtuacaoService;

  public atuacao = {

    id: '',

    isEdit: false,

    descricao: '',

    empresa: '',

    local: ''

  };

  public atuacaoObtida = {

    id: '',

    isEdit: false,

    descricao: '',

    empresa: '',

    local: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(AtuacaoService: AtuacaoService) {

    // debugger

    this._UrlBase = "http://localhost:5275/api/Atuacao/";

    this._AtuacaoService = AtuacaoService;

    this.atuacoes = []

  }

  public ObterRegistrosAtualizados(): void {

    this._AtuacaoService.getAll().subscribe(

      resultado => {

        // debugger

        this.atuacoes = resultado;

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

      descricao: this.atuacao.descricao,

      empresa: this.atuacao.empresa,

      local: this.atuacao.local,

    };

    // debugger

    if (!this.editar) {

      // debugger

      this._AtuacaoService.create(data).subscribe(

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

      this._AtuacaoService.update(this.idParaEdicao, data).subscribe(

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

  public adicionarAtuacao(): void {

    // debugger

    this.editar = false;

    this.submited = false;

    this.atuacao = {

      id: '',

      isEdit: false,

      descricao: '',

      empresa: '',

      local: ''

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

    this.atuacao = {

      id: '',

      isEdit: false,

      descricao: '',

      empresa: '',

      local: ''

    };

    // debugger

    this.obterAtuacao(Id);

    var atuacao = this.atuacaoObtida;

    // debugger

    this.editar = true;

  }

  public obterAtuacao(Id: string): void {

    this._AtuacaoService.get(Id).subscribe(

      resultado => {

        // debugger

        this.atuacaoObtida.id = resultado.id.toString();
        this.atuacaoObtida.descricao = resultado.descricao;
        this.atuacaoObtida.empresa = resultado.empresa;
        this.atuacaoObtida.local = resultado.local;
        this.atuacaoObtida.isEdit = true;

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

    this.atuacao.descricao = this.atuacaoObtida.descricao;
    this.atuacao.empresa = this.atuacaoObtida.empresa;
    this.atuacao.local = this.atuacaoObtida.local;
    this.idParaEdicao = this.atuacaoObtida.id;

    // debugger

  }

  public removerItem(Id: string): void {

    // debugger

    this.submited = false;

    this.atuacao = {

      id: '',

      isEdit: false,

      descricao: '',

      empresa: '',

      local: ''

    };

    // debugger

    this._AtuacaoService.delete(Id).subscribe(

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
