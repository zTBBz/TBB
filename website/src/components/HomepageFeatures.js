import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';
import Translate, {translate} from '@docusaurus/Translate';
import svg1 from '@site/static/img/undraw_docusaurus_mountain.png';
import svg2 from '@site/static/img/undraw_docusaurus_tree.png';

const FeatureList = [
  {
    title: (
      <Translate id="features.1">
        Feature 1
      </Translate>
    ),
    svg: svg1,
    description: (
      <Translate id="features.1.description">
        Feature 1 description
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.2">
        Feature 2
      </Translate>
    ),
    svg: svg2,
    description: (
      <span>
        <Translate id="features.2.description">
          Feature 2 description
        </Translate>
        {' '}
        <b>
          <Translate id="features.2.description.bold">
            (Feature 2 description part 2)
          </Translate>
        </b>
      </span>
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
