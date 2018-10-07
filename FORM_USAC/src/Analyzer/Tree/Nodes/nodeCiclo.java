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
public class nodeCiclo extends nodeModelGrupoCiclo {

    public elementoSimbolo simbolo;

    public nodeCiclo(tablaSimbolos tabla) {
        this.tablaSimbolos = tabla;
        this.nombreNodo = "nodeCiclo";

    }

    @Override
    public void execute() {

        ejecucionFinal();
    }

    public void ejecucionFinal() {

        cell idPregunta = atrib.get("idpregunta");
        simbolo = new elementoSimbolo(idPregunta, atrib, idPregunta.val);
        tablaSimbolos.insertSimbol(idPregunta.val.replace(" ", ""), simbolo);

        String salAcumul = "";
        for (nodeModel model : children) {

            if (model.nombreNodo.equals("nodeGrupo")) {
                model.execute();
                String temp2 = "";
                if (model.simbolo != null) {
                    if (model.simbolo.cadenaFinal != null) {
                        temp2 += model.simbolo.cadenaFinal;
                        model.simbolo.cadenaFinal = "";
                    }
                }
                concate(temp2);

            } else {

                model.execute();
                if (model.simbolo != null) {
                    if (model.simbolo.cadenaFinal != null) {
                        salAcumul += model.simbolo.cadenaFinal;
                        model.simbolo.cadenaFinal = "";
                    }
                }
            }
            //Tiene incluido el aplicable, la cadena de salida, post y pre 
        } 
        concate(salAcumul);
    }

    public void concate(String acumulado) {
        repeticion repe = new repeticion(tablaSimbolos, simbolo);
        String salida = repe.getCadena2();
        salida += acumulado;

        //model.simbolo.cadenaFinal = ""; //quitando el final
        salida += "\n\t\t}";
        simbolo.cadenaFinal = salida;
    }
}
