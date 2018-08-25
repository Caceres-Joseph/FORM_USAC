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
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Iterator;

public class readExcel {

    private static final String FILE_NAME = "/home/joseph/Documentos/Compi2/Ejemplo - Arbol/Arbol1.xlsx";
//    private static final String FILE_NAME = "/home/joseph/Documentos/Compi2/[COMPI2]PrimerProyecto/Impresion.xlsx";

    public String leer(int indexSheet) {
        String retorno = "";
        try {
            FileInputStream excelFile = new FileInputStream(new File(FILE_NAME));
            Workbook workbook = new XSSFWorkbook(excelFile);
            Sheet datatypeSheet = workbook.getSheetAt(indexSheet);
            readSheet sheet = new readSheet(datatypeSheet);
            retorno = sheet.leerOtros();

        } catch (FileNotFoundException e) {
            retorno = String.valueOf(e);
        } catch (IOException e) {   
            retorno = String.valueOf(e);
        }
        return retorno;
    }

    public String leerEncuesta(int indexSheet) {
        String retorno = "";
        try {
            FileInputStream excelFile = new FileInputStream(new File(FILE_NAME));
            Workbook workbook = new XSSFWorkbook(excelFile);
            Sheet datatypeSheet = workbook.getSheetAt(indexSheet);
            readSheet sheet = new readSheet(datatypeSheet);
            retorno = sheet.leerEncuesta();
        } catch (FileNotFoundException e) {
            retorno = String.valueOf(e);
        } catch (IOException e) {
            retorno = String.valueOf(e);
        }
        return retorno;
    }

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

                    System.out.print(currentRow.getRowNum());
                    System.out.print("-");
                    System.out.print(currentCell.getColumnIndex());
                    System.out.print(") ");
                    if (null == currentCell.getCellTypeEnum()) {
                        System.out.print("Celda null");
                    } else {
                        switch (currentCell.getCellTypeEnum()) {
                            case STRING:
                                System.out.print(currentCell.getStringCellValue());
                                break;
                            case NUMERIC:
                                System.out.print(currentCell.getNumericCellValue());
                                break;
                            case _NONE:
                                System.out.print("Nada");
                                break;
                            case BOOLEAN:
                                System.out.print("Boolean");
                                System.out.print(currentCell.getBooleanCellValue());
                                break;
                            case BLANK:
                                System.out.print("Blanco");
                                break;
                            case ERROR:
                                System.out.print("Error");
                                break;
                            case FORMULA:
                                System.out.print("Formula");

                                break;
                            default:
                                System.out.print("Formato de celda desconocido :(");
                                break;
                        }
                    }
                    System.out.print("---");
                }
                System.out.println();
            }
        } catch (FileNotFoundException e) {
            System.out.println(e);
        } catch (IOException e) {
            System.out.println(e);
        }
    }
}
