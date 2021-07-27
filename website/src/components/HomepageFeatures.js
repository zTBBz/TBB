import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';
import Translate, {translate} from '@docusaurus/Translate';
import svg1 from '@site/static/img/We_are_the_first!.png';
import svg2 from '@site/static/img/undraw_docusaurus_tree.png';

const FeatureList = [
  {
    title: (
      <Translate id="features.1">
        We are the first!
      </Translate>
    ),
    svg: svg1,
    description: (
      <Translate id="features.1.description">
        The first union of mods for SoR
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.2">
        Module system
      </Translate>
    ),
    svg: svg2,
    description: (
        <Translate id="features.2.description">
        You can disable any module in Union
        </Translate>
    ),
  },
];

function Feature({svg, title, description}) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <img src={svg} className={styles.featureSvg} alt={title}/>
      </div>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props}/>
          ))}
        </div>
      </div>
    </section>
  );
}
