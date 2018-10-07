/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package readExcel;

/**
 *
 * @author joseph
 */
import Analyzer.Tree.Tablas.tablaErrores;
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;

public class readExcel {

    public tablaErrores tablaErrores;
    Map<String, String> hashRetorno = new LinkedHashMap<>();

    private static final String FILE_NAME = "/home/joseph/Documentos/Compi2/Ejemplo - Arbol/Arbol1.xlsx";
//    private static final String FILE_NAME = "/home/joseph/Documentos/Compi2/[COMPI2]PrimerProyecto/Impresion.xlsx";

    public readExcel() {
        tablaErrores = new tablaErrores();

    }

//    public String leer(int indexSheet) {
//        String retorno = "";
//        try {
//            FileInputStream excelFile = new FileInputStream(new File(FILE_NAME));
//            Workbook workbook = new XSSFWorkbook(excelFile);
//            Sheet datatypeSheet = workbook.getSheetAt(indexSheet);
//            readSheet sheet = new readSheet(datatypeSheet);
//            retorno = sheet.leerOtros();
//
//            tablaErrores.concat(sheet.getTablaErrores());
//        } catch (FileNotFoundException e) {
//            retorno = String.valueOf(e);
//        } catch (IOException e) {
//            retorno = String.valueOf(e);
//        }
//        return retorno;
//    }

    public String extension(String fullPath) {
        int dot = fullPath.lastIndexOf(".");
        return fullPath.substring(dot + 1);
    }

    public String leerEncuesta(String ruta) {
        String retorno = "";
        try {
            if (this.extension(ruta).equals("xlsx")) {
                FileInputStream excelFile = new FileInputStream(new File(ruta));

                Workbook workbook = new XSSFWorkbook(excelFile);

                for (int i = 0; i < workbook.getNumberOfSheets(); i++) {
                    Sheet datatypeSheet = workbook.getSheetAt(i);
                    String nombreSeet = datatypeSheet.getSheetName().toLowerCase();

                    //Buscando la hoja que se llaman encuesta o encuestas
                    if (nombreSeet.contains("encuesta")) {
                        retorno = "";
                        retorno += "\n_encuesta\n";
                        readSheet sheet = new readSheet("encuesta",datatypeSheet);
                        retorno += sheet.leerEncuesta();
                        tablaErrores.concat(sheet.getTablaErrores());
                        hashRetorno.put("encuesta", retorno);
                    } else if (nombreSeet.contains("opcion")) {
                        retorno = "";
                        retorno += "\n_opcion\n";
                        readSheet sheet = new readSheet("opcion",datatypeSheet);
                        retorno += sheet.leerOtros();
                        tablaErrores.concat(sheet.getTablaErrores());
                        hashRetorno.put("opcion", retorno);
                    } else if (nombreSeet.contains("configu")) { //esta es la hoja opcional
                        retorno = "";
                        retorno += "\n_configuracion\n";
                        readSheet sheet = new readSheet("opcion",datatypeSheet);
                        retorno += sheet.leerOtros();
                        tablaErrores.concat(sheet.getTablaErrores());
                        hashRetorno.put("configuracion", retorno);
                    }
                }

                retorno = "";
                String enc = hashRetorno.get("encuesta");
                if (enc != null) {
                    retorno += enc;
                } else {
                    tablaErrores.insertErrorSemantic("Encuesta",0, 0, "No viene la hoja encuesta");
                }

                String opciones = hashRetorno.get("opcion");
                if (opciones != null) {
                    retorno += opciones;
                } else {
                    tablaErrores.insertErrorSemantic("Opciones",0, 0, "No viene la hoja opciones");
                }

                String configuracion = hashRetorno.get("configuracion");
                if (configuracion != null) {
                    retorno += configuracion;
                }else{
                    retorno += "\n_configuracion\n";
                }

            } else {
                retorno = "El archivo que seleccionó no es .xlsx";
                tablaErrores.println(retorno);
            }
        } catch (FileNotFoundException e) {
            retorno = String.valueOf(e);
            tablaErrores.println(e);
        } catch (IOException e) {
            retorno = String.valueOf(e);
            tablaErrores.println(e);
        }

        return retorno;
    }

//    public String leerEncuesta(int indexSheet) {
//        String retorno = "";
//        try {
//            FileInputStream excelFile = new FileInputStream(new File(FILE_NAME));
//            Workbook workbook = new XSSFWorkbook(excelFile);
//            Sheet datatypeSheet = workbook.getSheetAt(indexSheet);
//            readSheet sheet = new readSheet(datatypeSheet);
//            retorno = sheet.leerEncuesta();
//            tablaErrores.concat(sheet.getTablaErrores());
//        } catch (FileNotFoundException e) {
//            retorno = String.valueOf(e);
//        } catch (IOException e) {
//            retorno = String.valueOf(e);
//        }
//
//        tablaErrores.println(retorno);
//        return retorno;
//    }

    public void leer2(int sheet) {
        try {
            FileInputStream excelFile = new FileInputStream(new File(FILE_NAME));
            Workbook workbook = new XSSFWorkbook(excelFile);
            Sheet datatypeSheet = workbook.getSheetAt(sheet);
            Iterator<Row> iterator = datatypeSheet.iterator();

            while (iterator.hasNext()) {

                Row currentRow = iterator.next();
                Iterator<Cell> cellIterator = currentRow.iterator();

                while (cellIterator.hasNext()) {

                    Cell currentCell = cellIterator.next();
                    //getCellTypeEnum shown as deprecated for version 3.15
                    //getCellTypeEnum ill be renamed to getCellType starting from version 4.0

                    tablaErrores.print(currentRow.getRowNum());
                    tablaErrores.print("-");
                    tablaErrores.print(currentCell.getColumnIndex());
                    tablaErrores.print(") ");
                    if (null == currentCell.getCellTypeEnum()) {
                        tablaErrores.print("Celda null");
                    } else {
                        switch (currentCell.getCellTypeEnum()) {
                            case STRING:
                                tablaErrores.print(currentCell.getStringCellValue());
                                break;
                            case NUMERIC:
                                tablaErrores.print(currentCell.getNumericCellValue());
                                break;
                            case _NONE:
                                tablaErrores.print("Nada");
                                break;
                            case BOOLEAN:
                                tablaErrores.print("Boolean");
                                tablaErrores.print(currentCell.getBooleanCellValue());
                                break;
                            case BLANK:
                                tablaErrores.print("Blanco");
                                break;
                            case ERROR:
                                tablaErrores.print("Error");
                                break;
                            case FORMULA:
                                tablaErrores.print("Formula");

                                break;
                            default:
                                tablaErrores.print("Formato de celda desconocido :(");
                                break;
                        }
                    }
                    tablaErrores.print("---");
                }
                tablaErrores.println("");
            }
        } catch (FileNotFoundException e) {
            tablaErrores.println(e);
        } catch (IOException e) {
            tablaErrores.println(e);
        }
    }

    public tablaErrores getTablaErrores() {
        return tablaErrores;
    }

}
