import { Component } from '@angular/core';
import { CompromissoService } from '../services/compromisso.service';
import { Compromisso } from '../interfaces/Compromisso.interface';

@Component({

  selector: 'app-dados-compromisso',

  templateUrl: './dados-compromisso.component.html'

})

export class DadosCompromissos {

  public compromissos: Compromisso[];

  public _UrlBase: string;

  public _CompromissoService: CompromissoService;

  public compromisso = {

    id: '',

    isEdit: false,

    descricao: '',

    horaInicio: '',

    local: ''

  };

  public compromissoObtida = {

    id: '',

    isEdit: false,

    descricao: '',

    horaInicio: '',

    local: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(CompromissoService: CompromissoService) {

    // debugger

    this._UrlBase = "http://localhost:5275/api/Compromisso/";

    this._CompromissoService = CompromissoService;

    this.compromissos = []

  }

  public ObterRegistrosAtualizados(): void {

    this._CompromissoService.getAll().subscribe(

      resultado => {

        // debugger

        this.compromissos = resultado;

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

      descricao: this.compromisso.descricao,

      horaInicio: this.compromisso.horaInicio,

      local: this.compromisso.local,

    };

    // debugger

    if (!this.editar) {

      // debugger

      this._CompromissoService.create(data).subscribe(

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

      this._CompromissoService.update(this.idParaEdicao, data).subscribe(

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

  public adicionarCompromisso(): void {

    // debugger

    this.editar = false;

    this.submited = false;

    this.compromisso = {

      id: '',

      isEdit: false,

      descricao: '',

      horaInicio: '',

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

    this.compromisso = {

      id: '',

      isEdit: false,

      descricao: '',

      horaInicio: '',

      local: ''

    };

    // debugger

    this.obterCompromisso(Id);

    var compromisso = this.compromissoObtida;

    // debugger

    this.editar = true;

  }

  public obterCompromisso(Id: string): void {

    this._CompromissoService.get(Id).subscribe(

      resultado => {

        // debugger

        this.compromissoObtida.id = resultado.id.toString();
        this.compromissoObtida.descricao = resultado.descricao;
        this.compromissoObtida.horaInicio = resultado.horaInicio;
        this.compromissoObtida.local = resultado.local;
        this.compromissoObtida.isEdit = true;

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

    this.compromisso.descricao = this.compromissoObtida.descricao;
    this.compromisso.horaInicio = this.compromissoObtida.horaInicio;
    this.compromisso.local = this.compromissoObtida.local;
    this.idParaEdicao = this.compromissoObtida.id;

    // debugger

  }

  public removerItem(Id: string): void {

    // debugger

    this.submited = false;

    this.compromisso = {

      id: '',

      isEdit: false,

      descricao: '',

      horaInicio: '',

      local: ''

    };

    // debugger

    this._CompromissoService.delete(Id).subscribe(

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
