import { Component } from '@angular/core';
import { DespesaService } from '../services/despesa.service';
import { Despesa } from '../interfaces/Despesa.interface';

@Component({

  selector: 'app-dados-despesa',

  templateUrl: './dados-despesa.component.html'

})

export class DadosDespesas {

  public despesas: Despesa[];

  public _UrlBase: string;

  public _DespesaService: DespesaService;

  public despesa = {

    id: '',

    isEdit: false,

    descricao: '',

    valor: 0.0,

    local: ''

  };

  public despesaObtida = {

    id: '',

    isEdit: false,

    descricao: '',

    valor: 0.0,

    local: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(DespesaService: DespesaService) {

    // debugger

    this._UrlBase = "http://localhost:5275/api/Despesa/";

    this._DespesaService = DespesaService;

    this.despesas = []

  }

  public ObterRegistrosAtualizados(): void {

    this._DespesaService.getAll().subscribe(

      resultado => {

        // debugger

        this.despesas = resultado;

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

      descricao: this.despesa.descricao,

      valor: this.despesa.valor,

      local: this.despesa.local,

    };

    // debugger

    if (!this.editar) {

      // debugger

      this._DespesaService.create(data).subscribe(

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

      this._DespesaService.update(this.idParaEdicao, data).subscribe(

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

  public adicionarDespesa(): void {

    // debugger

    this.editar = false;

    this.submited = false;

    this.despesa = {

      id: '',

      isEdit: false,

      descricao: '',

      valor: 0.0,

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

    this.despesa = {

      id: '',

      isEdit: false,

      descricao: '',

      valor: 0.0,

      local: ''

    };

    // debugger

    this.obterDespesa(Id);

    var despesa = this.despesaObtida;

    // debugger

    this.editar = true;

  }

  public obterDespesa(Id: string): void {

    this._DespesaService.get(Id).subscribe(

      resultado => {

        // debugger

        this.despesaObtida.id = resultado.id.toString();
        this.despesaObtida.descricao = resultado.descricao;
        this.despesaObtida.valor = resultado.valor;
        this.despesaObtida.local = resultado.local;
        this.despesaObtida.isEdit = true;

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

    this.despesa.descricao = this.despesaObtida.descricao;
    this.despesa.valor = this.despesaObtida.valor;
    this.despesa.local = this.despesaObtida.local;
    this.idParaEdicao = this.despesaObtida.id;

    // debugger

  }

  public removerItem(Id: string): void {

    // debugger

    this.submited = false;

    this.despesa = {

      id: '',

      isEdit: false,

      descricao: '',

      valor: 0.0,

      local: ''

    };

    // debugger

    this._DespesaService.delete(Id).subscribe(

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
