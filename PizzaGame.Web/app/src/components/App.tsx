import React from 'react';
import * as signalR from '@microsoft/signalr';
import 'bootstrap/dist/css/bootstrap.css';
import { GameComponent } from './GameComponent';

const App: React.FC = () => {

  const hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:8080/game")
      .configureLogging(signalR.LogLevel.Information)
      .build();
  
  hubConnection.start().then(a => {
    console.log('Connected with SignalR.');
  });

  return <div className={'bg-secondary h-100'}>
    <div className={'container text-center pt-5'}>
      <div className={'card'}>
        <div className={'card-header'}>
          <h1>Pizza game</h1>
        </div>
        <div className={'card-body'}>
          <div className={'card-text p-4'}>
            <GameComponent
                hubConnection={hubConnection}
            />
          </div>
        </div>
      </div>
    </div>
  </div>;
};

export default App;