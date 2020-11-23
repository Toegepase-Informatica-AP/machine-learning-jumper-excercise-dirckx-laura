# Jumper Exercise

#### Laura Dirckx & Nico Chauvaux 

### Stap 1.

Brainstorming, voorbeelden bekijken van ML-agents.

### Stap 2.

New Unity Project, dan een stage maken, dan Agent overnemen van ML-agents.

### Stap 3.

Scripts bekijken en aanpassen van ML-agents voorbeeld (WallJump).

### Stap 4.

Agent maken, en logica voor agent toevoegen. + Reward system.

### Stap 5.

#### Eerste training:


**yml-parameters:**

    behaviors:

    Jump:
  
    trainer_type: ppo
    max_steps: 5.0e7
    time_horizon: 64
    summary_freq: 10000
    keep_checkpoints: 5
    checkpoint_interval: 50000
    
    hyperparameters:
      batch_size: 32
      buffer_size: 9600
      learning_rate: 3.0e-4
      learning_rate_schedule: constant
      beta: 5.0e-3
      epsilon: 0.2
      lambd: 0.95
      num_epoch: 3

    network_settings:
      num_layers: 2
      hidden_units: 128
      normalize: false
      vis_encoder_type: simple

    reward_signals:
      extrinsic:
        strength: 1.0
        gamma: 0.99
      curiosity:
        strength: 0.01
        gamma: 0.99
        encoding_size: 256
        learning_rate : 1e-3


****Reward systeem:****

* collision met enemyblock: -1
* het pakken van een coin: +0.1

![](FirstRunJumper.png)

****Conclusie:**** rare resultaten. Het reward systeem herzien. Word ook niet afgestraft om te springen dus als resultaat springt de Agent continui.

#### Tweede training:


### Bronvermelding:

Schuchmann, S. S. (2020, May 19). Ultimate Walkthrough for ML-Agents in Unity3D. Towardsdatascience. https://towardsdatascience.com/ultimate-walkthrough-for-ml-agents-in-unity3d-5603f76f68b?gi=24091b69b52d