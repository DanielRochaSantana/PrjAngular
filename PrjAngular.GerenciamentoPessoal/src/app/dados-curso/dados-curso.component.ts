import { Component } from '@angular/core';
import { CursoService } from '../services/curso.service';
import { Curso } from '../interfaces/Curso.interface';

@Component({

  selector: 'app-dados-curso',

  templateUrl: './dados-curso.component.html'

})

export class DadosCursos {

  public cursos: Curso[];

  public _UrlBase: string;

  public _CursoService: CursoService;

  public curso = {

    id: '',

    isEdit: false,

    descricao: '',

    instituicao: '',

    local: ''

  };

  public cursoObtida = {

    id: '',

    isEdit: false,

    descricao: '',

    instituicao: '',

    local: ''

  };

  public submited = false;

  public listar = false;

  public editar = false;

  public idParaEdicao = '';

  constructor(CursoService: CursoService) {

    // debugger

    this._UrlBase = "http://localhost:5275/api/Curso/";

    this._CursoService = CursoService;

    this.cursos = []

  }

  public ObterRegistrosAtualizados(): void {

    this._CursoService.getAll().subscribe(

      resultado => {

        // debugger

        this.cursos = resultado;

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

      descricao: this.curso.descricao,

      instituicao: this.curso.instituicao,

      local: this.curso.local,

    };

    // debugger

    if (!this.editar) {

      // debugger

      this._CursoService.create(data).subscribe(

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

      this._CursoService.update(this.idParaEdicao, data).subscribe(

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

  public adicionarCurso(): void {

    // debugger

    this.editar = false;

    this.submited = false;

    this.curso = {

      id: '',

      isEdit: false,

      descricao: '',

      instituicao: '',

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

    this.curso = {

      id: '',

      isEdit: false,

      descricao: '',

      instituicao: '',

      local: ''

    };

    // debugger

    this.obterCurso(Id);

    var curso = this.cursoObtida;

    // debugger

    this.editar = true;

  }

  public obterCurso(Id: string): void {

    this._CursoService.get(Id).subscribe(

      resultado => {

        // debugger

        this.cursoObtida.id = resultado.id.toString();
        this.cursoObtida.descricao = resultado.descricao;
        this.cursoObtida.instituicao = resultado.instituicao;
        this.cursoObtida.local = resultado.local;
        this.cursoObtida.isEdit = true;

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

    this.curso.descricao = this.cursoObtida.descricao;
    this.curso.instituicao = this.cursoObtida.instituicao;
    this.curso.local = this.cursoObtida.local;
    this.idParaEdicao = this.cursoObtida.id;

    // debugger

  }

  public removerItem(Id: string): void {

    // debugger

    this.submited = false;

    this.curso = {

      id: '',

      isEdit: false,

      descricao: '',

      instituicao: '',

      local: ''

    };

    // debugger

    this._CursoService.delete(Id).subscribe(

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
