using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Logic_Script : MonoBehaviour
{
    public int player_score;
    public Text score_text;
    public Text end_text;
    public Text high_score_text;
    public int high_score;
    public GameObject game_over_screen;
    public Boolean game_state;
    public Boolean missed=true;
    public Boolean knocked_state=false;

    [ContextMenu("Increment Score")]
    public void add_score(int score_to_add){
        player_score+=score_to_add;
        score_text.text="Score: "+player_score;
        if (player_score>high_score){
            high_score=player_score;
        }
        high_score_text.text="High Score: "+high_score;
    }
    public void reset_score(){
        player_score=0;
        score_text.text="Score: "+player_score;
    }
    void Start()
    {
        score_text.text="Score: 0";
        high_score_text.text="High Score: 0";
        game_state=true;
    }

    public void restart_game(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void game_over(int win){
        if (win==1){
            end_text.text = "Gryffindor Wins!";
        }
        else if (win==0){
            end_text.text = "Gryffindor Loses :(";
        }
        else if (win ==2){
            end_text.text="Lol You Crashed!";
        }
        game_over_screen.SetActive(true);
    }
}
