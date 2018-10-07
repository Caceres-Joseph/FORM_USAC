/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Analyzer.Tree.Nodes;

import Analyzer.Tree.Columnas.Encuesta.codigoPost;
import Analyzer.Tree.Columnas.Encuesta.codigoPre;
import Analyzer.Tree.Columnas.Encuesta.repeticion;
import Analyzer.Tree.NodTemp.nodoString;
import Analyzer.Tree.Tablas.elementoSimbolo;
import Analyzer.Tree.Tablas.tablaSimbolos;
import Analyzer.Tree.nodeModel;
import Analyzer.Tree.nodeModelGrupoCiclo;
import readExcel.cell;

/**
 *
 * @author joseph
 */
public class nodeGrupo extends nodeModelGrupoCiclo {
 

    public nodeGrupo(tablaSimbolos tabla) {
        this.tablaSimbolos = tabla;
        this.nombreNodo = "nodeGrupo";
    }

    @Override
    public void execute() {
        //this.mensajeDeEjecucion();
        //this.imprimir(); 
        //nodoString nod = new nodoString();
        //this.ejectuarHijosSinLlamar(nod);
        ejecucionFinal();
        //tablaSimbolos.tablaErrores.println("[nodeGrupo]" + nod.cadena);
    }

    @Override
    public void executeSinLlamar(nodoString nodCad) {
        //este es un grupo dentro de otro grupo

    }

    public void ejecucionFinal() {
        nodoString nod = new nodoString();

        for (nodeModel model : children) {
//            System.out.println(model.nombreNodo);
            if (model.nombreNodo.equals("nodeGrupo")) {
                //aqui le tengo que quitar el post
                //le tengo que quitar el pre
                //la cadena ejecucion
                //la cadena final
                nodeGrupo grup = (nodeGrupo) model;
                grup.execute();
                nod.cadena += grup.simbolo.cadenaFinal;
                grup.simbolo.cadenaFinal = "";

                //quitando esos parametros
            } else {
                model.executeSinLlamar(nod);
            }

        }
        ejecutarGrupo(nod);

    }

    public void ejecutarGrupo(nodoString nod) {

        //nodoString nod = new nodoString();
        //this.ejectuarHijosSinLlamar(nod);
        //this.imprimir(); 
        cell idPregunta = atrib.get("idpregunta");
        simbolo = new elementoSimbolo(idPregunta, atrib, idPregunta.val);
        tablaSimbolos.insertSimbol(idPregunta.val.replace(" ", ""), simbolo);

        String retorno = "";
        retorno += "\n\tGrupo " + idPregunta.val + "(){";
        retorno += "\n\t\tRespuesta resp = nuevo Respuesta();";
        retorno += nod.cadena;

        retorno += "\n\t}";

        simbolo.cadenaContenido = retorno;;

        codigoPre codPre = new codigoPre(tablaSimbolos, simbolo);
        simbolo.cadenaPre = codPre.getCadena();
        codigoPost codPost = new codigoPost(tablaSimbolos, simbolo);
        simbolo.cadenaPost = codPost.getCadena();

        simbolo.codigoEjecucion = idPregunta.val + "();";

        repeticion repe = new repeticion(tablaSimbolos, simbolo);
        String salida = repe.getCadena();
  
        simbolo.cadenaFinal = salida;

    } 
}
