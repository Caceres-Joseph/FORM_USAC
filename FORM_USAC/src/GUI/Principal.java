/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GUI;

import java.io.IOException;
import javafx.application.Application; 
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene; 
import javafx.stage.Stage;
import javafx.stage.WindowEvent;

/**
 *
 * @author joseph
 */
public class Principal extends Application {

    public static Stage sta;

    
    @Override
    public void start(Stage stage) throws IOException {
         
        Parent root = FXMLLoader.load(getClass().getResource("/GUI/Navegador.fxml"));
//        Parent root= FXMLLoader.load();
         
        Scene scene = new Scene(root); 
        stage.setScene(scene);
        stage.show();
        stage.setOnCloseRequest((WindowEvent we) -> {
            System.exit(0);
        });      
        sta=stage;
    }

    public  void correr(String[] args){
        launch(args);
    }
    
    

}
