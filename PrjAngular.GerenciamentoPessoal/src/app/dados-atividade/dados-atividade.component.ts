import { Component } from '@angular/core';
import { AtividadeService } from '../services/atividade.service';
import { Atividade } from '../interfaces/Atividade.interface';

@Component({

  selector: 'app-dados-atividade',

  templateUrl: './dados-atividade.component.html'

})

export class DadosAtividades {

  public atividades: Atividade[];

  public _UrlBase: string;

  public _AtividadeService: AtividadeService;

  public atividade = {

    id: '',

    isEdit: false,

    descricao: '',

    horario: '',

    local: ''

  };

  public atividadeObtida = {

    id: '',

    isEdit: false,

    descricao: '',

    horario: '',

    local: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(AtividadeService: AtividadeService) {

    // debugger

    this._UrlBase = "http://localhost:5275/api/Atividade/";

    this._AtividadeService = AtividadeService;

    this.atividades = []

  }

  public ObterRegistrosAtualizados(): void {

    this._AtividadeService.getAll().subscribe(

      resultado => {

        // debugger

        this.atividades = resultado;

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

      descricao: this.atividade.descricao,

      horario: this.atividade.horario,

      local: this.atividade.local,

    };

    // debugger

    if (!this.editar) {

      // debugger

      this._AtividadeService.create(data).subscribe(

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

      this._AtividadeService.update(this.idParaEdicao, data).subscribe(

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

  public adicionarAtividade(): void {

    // debugger

    this.editar = false;

    this.submited = false;

    this.atividade = {

      id: '',

      isEdit: false,

      descricao: '',

      horario: '',

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

    this.atividade = {

      id: '',

      isEdit: false,

      descricao: '',

      horario: '',

      local: ''

    };

    // debugger

    this.obterAtividade(Id);

    var atividade = this.atividadeObtida;

    // debugger

    this.editar = true;

  }

  public obterAtividade(Id: string): void {

    this._AtividadeService.get(Id).subscribe(

      resultado => {

        // debugger

        this.atividadeObtida.id = resultado.id.toString();
        this.atividadeObtida.descricao = resultado.descricao;
        this.atividadeObtida.horario = resultado.horario;
        this.atividadeObtida.local = resultado.local;
        this.atividadeObtida.isEdit = true;

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

    this.atividade.descricao = this.atividadeObtida.descricao;
    this.atividade.horario = this.atividadeObtida.horario;
    this.atividade.local = this.atividadeObtida.local;
    this.idParaEdicao = this.atividadeObtida.id;

    // debugger

  }

  public removerItem(Id: string): void {

    // debugger

    this.submited = false;

    this.atividade = {

      id: '',

      isEdit: false,

      descricao: '',

      horario: '',

      local: ''

    };

    // debugger

    this._AtividadeService.delete(Id).subscribe(

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
